﻿using ForumSystem.Services.Messages;
using ForumSystem.Services.Users;
using ForumSystem.Web.Infrastructure.Extensions;
using ForumSystem.Web.InputModels.Chat;
using ForumSystem.Web.ViewModels.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForumSystem.Web.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IMessagesService messagesService;

        public ChatController(
            IUsersService usersService,
            IMessagesService messagesService)
        {
            this.usersService = usersService;
            this.messagesService = messagesService;
        }

        public IActionResult All() => this.View();

        public async Task<IActionResult> SendMessage()
        {
            var viewModel = new ChatSendMessageInputModel
            {
                Users = await this.usersService.GetAllAsync<ChatUserViewModel>(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ChatSendMessageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Users = await this.usersService.GetAllAsync<ChatUserViewModel>();

                this.View(input);
            }

            await this.messagesService.CreateAsync(input.Message, this.User.GetId(), input.ReceiverId);

            return this.RedirectToAction(nameof(WithUser), new { id = input.ReceiverId });
        }

        public async Task<IActionResult> WithUser(string id)
        {
            var userId = this.User.GetId();
            var viewModel = new ChatWithUserViewModel
            {
                User = await this.usersService.GetByIdAsync<ChatUserViewModel>(id),
                Messages = await this.messagesService.GetAllWithUserAsync<ChatMessagesWithUserViewModel>(userId, id),
            };

            return this.View(viewModel);
        }
    }
}
