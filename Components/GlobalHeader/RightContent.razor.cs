using AntDesign;
using AntDesign.ProLayout;
using DIIS.PersonApp.IServices;
using DIIS.PersonApp.Models;
using DIIS.PersonApp.Services;
using Microsoft.AspNetCore.Components;

namespace DIIS.PersonApp.Components.GlobalHeader
{
    public partial class RightContent
    {
        private CurrentUser _currentUser = new CurrentUser();
        private NoticeIconData[]? _notifications = { };
        private NoticeIconData[]? _messages = { };
        private NoticeIconData[]? _events = { };
        private int _count = 0;
        private List<AutoCompleteDataItem<string>> DefaultOptions { get; set; } = new List<AutoCompleteDataItem<string>>
        {
            new AutoCompleteDataItem<string>
            {
                Label = "umi ui",
                Value = "umi ui"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Table",
                Value = "Pro Table"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Layout",
                Value = "Pro Layout"
            }
        };
        public AvatarMenuItem[] AvatarMenuItems { get; set; } = new AvatarMenuItem[]
        {
            //new() { Key = "center", IconType = "user", Option = "个人中心"},
            new() { Key = "profile", IconType = "user", Option = "profile"},
            new() { IsDivider = true },
            new() { Key = "logout", IconType = "logout", Option = "Logout"}
        };

        [Inject] protected NavigationManager? NavigationManager { get; set; }

        [Inject] protected IUserService? UserService { get; set; }
        [Inject] protected IProjectService? ProjectService { get; set; }
        [Inject] protected MessageService? MessageService { get; set; }

        [Inject] protected IPSUOAuth2Services? OAuth2Services { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            SetClassMap();
            _currentUser = await UserService.GetCurrentUserAsync();
            var notices = await ProjectService.GetNoticesAsync();
            if (notices != null)
            {
                _notifications = notices.Where(x => x.Type == "notification").Cast<NoticeIconData>().ToArray();
                _messages = notices.Where(x => x.Type == "message").Cast<NoticeIconData>().ToArray();
                _events = notices.Where(x => x.Type == "event").Cast<NoticeIconData>().ToArray();
                _count = notices.Length;
            }
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add("right");
        }

        private async Task handleProfileDropdown(char event_id)
        {
            switch (event_id)
            {
                case '1': // Profile click
                    NavigationManager.NavigateTo("/User/Profile");
                    break;
                case '2': // logout click
                    await OAuth2Services.SignOut();
                    NavigationManager.NavigateTo("/User/Logout", true);
                    break;
            }

        }

        public void HandleSelectLang(MenuItem item)
        {
        }

        public async Task HandleClear(string key)
        {
            switch (key)
            {
                case "notification":
                    _notifications = new NoticeIconData[] { };
                    break;
                case "message":
                    _messages = new NoticeIconData[] { };
                    break;
                case "event":
                    _events = new NoticeIconData[] { };
                    break;
            }
            await MessageService.Success($"清空了{key}");
        }

        public async Task HandleViewMore(string key)
        {
            await MessageService.Info("Click on view more");
        }

        //public void SignIn()
        //{
        //    string url = OAuth2Services.CallAuthorize();
        //    NavigationManager.NavigateTo(url);
        //}
    }
}
