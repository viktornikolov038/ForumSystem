using AutoMapper;
using AutoMapper.QueryableExtensions;
using ForumSystem.Data;
using ForumSystem.Data.Models;
using ForumSystem.Services.Providers.DateTime;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Services.Reports
{
    public class ReplyReportsService : IReplyReportsService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        private readonly IDateTimeProvider dateTimeProvider;

        public ReplyReportsService(ApplicationDbContext db, IMapper mapper, IDateTimeProvider dateTimeProvider)
        {
            this.db = db;
            this.mapper = mapper;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task CreateAsync(string description, int replyId, string authorId)
        {
            var replyReport = new ReplyReport
            {
                Description = description,
                ReplyId = replyId,
                AuthorId = authorId,
                CreatedOn = this.dateTimeProvider.Now()
            };

            await this.db.ReplyReports.AddAsync(replyReport);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var replyReport = await this.db.ReplyReports.FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);
            if (replyReport == null)
            {
                return false;
            }

            replyReport.IsDeleted = true;
            replyReport.DeletedOn = this.dateTimeProvider.Now();

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<TModel> GetByIdAsync<TModel>(int id)
            => await this.db.ReplyReports
                .AsNoTracking()
                .Where(r => r.Id == id && !r.IsDeleted)
                .ProjectTo<TModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
            => await this.db.ReplyReports
                .AsNoTracking()
                .Where(r => !r.IsDeleted && !r.Reply.IsDeleted)
                .ProjectTo<TModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
    }
}
