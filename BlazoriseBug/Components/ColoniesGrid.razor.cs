using Blazorise.DataGrid;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazoriseBug.Components
{
    public partial class ColoniesGrid
    {
        private AnimalPicker animalPicker;

        private void CovanceNoPicker()
        {
             animalPicker.ShowAnimalPicker();
        }

    }
}