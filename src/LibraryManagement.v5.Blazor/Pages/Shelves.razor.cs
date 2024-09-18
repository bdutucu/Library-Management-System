using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.v5.Shelves;
using LibraryManagement.v5.Permissions;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
namespace LibraryManagement.v5.Blazor.Pages;

public partial class Shelves
{
    private IReadOnlyList<ShelfDto> ShelfList { get; set; }

    private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
    private int CurrentPage { get; set; }
    private string CurrentSorting { get; set; }
    private int TotalCount { get; set; }

    private bool CanCreateShelf{ get; set; }
    private bool CanEditShelf { get; set; }
    private bool CanDeleteShelf { get; set; }

    private CreateShelfDto NewShelf { get; set; }

    private Guid EditingShelfId { get; set; }
    private UpdateShelfDto EditingShelf { get; set; }

    private Modal CreateShelfModal { get; set; }
    private Modal EditShelfModal { get; set; }

    private Validations CreateValidationsRef;

    private Validations EditValidationsRef;

    public Shelves()
    {
        NewShelf = new CreateShelfDto();
        EditingShelf = new UpdateShelfDto();
    }

    protected override async Task OnInitializedAsync()
    {
        await SetPermissionsAsync();
        await GetShelvesAsync();
    }

    private async Task SetPermissionsAsync()
    {
        CanCreateShelf = await AuthorizationService
            .IsGrantedAsync(v5Permissions.Shelves.Create);

        CanEditShelf = await AuthorizationService
            .IsGrantedAsync(v5Permissions.Shelves.Edit);

        CanDeleteShelf = await AuthorizationService
            .IsGrantedAsync(v5Permissions.Shelves.Delete);
    }

    private async Task GetShelvesAsync()
    {
        var result = await ShelfAppService.GetListAsync(
            new GetShelfListDto
            {
                MaxResultCount = PageSize,
                SkipCount = CurrentPage * PageSize,
                Sorting = CurrentSorting
            }
        );

        ShelfList = result.Items;
        TotalCount = (int)result.TotalCount;
    }

    private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<ShelfDto> e)
    {
        CurrentSorting = e.Columns
            .Where(c => c.SortDirection != SortDirection.Default)
            .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
            .JoinAsString(",");
        CurrentPage = e.Page - 1;

        await GetShelvesAsync();

        await InvokeAsync(StateHasChanged);
    }

    private void OpenCreateShelfModal()
    {
        CreateValidationsRef.ClearAll();

        NewShelf = new CreateShelfDto();
        CreateShelfModal.Show();
    }

    private void CloseCreateShelfModal()
    {
        CreateShelfModal.Hide();
    }

    private void OpenEditShelfModal(ShelfDto shelf)
    {
        EditValidationsRef.ClearAll();

        EditingShelfId = shelf.Id;
        EditingShelf = ObjectMapper.Map<ShelfDto, UpdateShelfDto>(shelf);
        EditShelfModal.Show();
    }

    private async Task DeleteShelfAsync(ShelfDto shelf)
    {
        var confirmMessage = L["ShelfDeletionConfirmationMessage", shelf.Name];
        if (!await Message.Confirm(confirmMessage))
        {
            return;
        }

        await ShelfAppService.DeleteAsync(shelf.Id);
        await GetShelvesAsync();
    }

    private void CloseEditShelfModal()
    {
        EditShelfModal.Hide();
    }

    private async Task CreateShelfAsync()
    {
        if (await CreateValidationsRef.ValidateAll())
        {
            await ShelfAppService.CreateAsync(NewShelf);
            await GetShelvesAsync();
            CreateShelfModal.Hide();
        }
    }

    private async Task UpdateShelfAsync()
    {
        if (await EditValidationsRef.ValidateAll())
        {
            await ShelfAppService.UpdateAsync(EditingShelfId, EditingShelf);
            await GetShelvesAsync();
            EditShelfModal.Hide();
        }
    }
}