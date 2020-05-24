## Define permission
- Vào Class GWebsitePermissions.cs trong project GWebsite.AbpZeroTemplate.Core để define permission
```C#
public const string Pages_Administration_MenuClient =				"Pages.Administration.MenuClient";
public const string Pages_Administration_MenuClient_Create =	"Pages.Administration.MenuClient.Create";
public const string Pages_Administration_MenuClient_Edit =		"Pages.Administration.MenuClient.Edit";
public const string Pages_Administration_MenuClient_Delete =	"Pages.Administration.MenuClient.Delete";
```
- Vào class GWebsiteAuthorizationProvider.cs rong project GWebsite.AbpZeroTemplate.Core để add perrmission vào treeview
```C#
var menuClients = administration.CreateChildPermission(AppPermissions.Pages_Administration_MenuClient, L("MenuClient"));
menuClients.CreateChildPermission(AppPermissions.Pages_Administration_MenuClient_Create, L("CreatingNewMenuClient"));
menuClients.CreateChildPermission(AppPermissions.Pages_Administration_MenuClient_Edit, L("EditingMenuClient"));
menuClients.CreateChildPermission(AppPermissions.Pages_Administration_MenuClient_Delete, L("DeletingMenuClient"));
```

## Add permission for function service

```C#
[AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient)]
public class MenuService : GWebsiteAppServiceBase, IMenuService
{
    private readonly IRepository<MenuClient, int> _menuRepository;

    public MenuService(IRepository<MenuClient, int> menuRepository)
    {
        _menuRepository = menuRepository;
    }

    [AbpAuthorize(GWebsitePermissions.Pages_Administration_MenuClient_Create)]
    public async Task<MenuClientDto> CreateMenuClient(CreateMenuClientInput input)
    {
        var menu = input.MapTo<MenuClient>();
        menu = await _menuRepository.InsertAsync(menu);
        await CurrentUnitOfWork.SaveChangesAsync();
        return menu.MapTo<MenuClientDto>();
    }
}
```

## Run webapi MenuClient với permission
- Mở frontend vào menu Role-> Change Role để thêm permission cho MenuClient
- Sau đó run api MenuClient 