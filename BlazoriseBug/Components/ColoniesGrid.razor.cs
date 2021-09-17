using Blazorise.DataGrid;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazoriseBug.Components
{
    public partial class ColoniesGrid
    {
        private IEnumerable<Colony> colonies;

        private bool isLoading { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await RefreshColonies();
            }
        }

        private async Task RefreshColonies()
        {
            isLoading = true;
            StateHasChanged();

            //using (BlazoriseBugRepository cairsRepository = new BlazoriseBugRepository(CairsContextFactory.CreateDbContext(), AuthenticationStateProvider))
            //{
            colonies = new List<Colony>();
            //}

            isLoading = false;
            StateHasChanged();
        }


        private bool newAllocationDisabled = false;

        private void SetNewAllocationDisabled() //determine if the new allocation button is disabled
        {
            RefreshColonies();
            newAllocationDisabled = !newAllocationDisabled;

            StateHasChanged();
        }

        private void NewAllocation()
        {
        }
    }
}