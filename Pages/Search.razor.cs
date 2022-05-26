using DIIS.PersonApp.Entities;
using DIIS.PersonApp.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DIIS.PersonApp.Pages
{
    public partial class Search
    {
        [Inject] public IDevSampleService DevSampleService { get; set; }

        private string txtValue { get; set; }
        private string title = "New";
        private bool visible = false;
        private List<string> options = new List<string>();
        private IDictionary<decimal, (bool edit, DevSample data)> editCache = new Dictionary<decimal, (bool edit, DevSample data)>();

        private List<DevSample> listOfData = new List<DevSample>();
        private DevSample tempInsert = new DevSample();

        private void startEdit(decimal id)
        {
            var data = editCache[id];
            editCache[id] = (true, data.data); // add a copy in cache
        }

        private void cancelEdit(decimal id)
        {
            var data = listOfData.FirstOrDefault(item => item.Id == id);
            editCache[id] = (false, data); // recovery
        }

        private async Task saveEdit(decimal id)
        {
            var index = listOfData.FindIndex(item => item.Id == id);
            listOfData[index] = editCache[id].data; // apply the copy to data source 

            await DevSampleService.UpdateCustomer(listOfData[index]);
            editCache[id] = (false, listOfData[index]); // don't affect rows in editing
        }

        private async Task deleteRow(decimal id)
        {
            await DevSampleService.DeleteCustomer(id);
            await LoadData();
        }

        public async Task OnSearch()
        {
            await message.Loading($"searching {txtValue}", 2);
            await LoadData();
        }

        protected async Task LoadData()
        {
            if (!String.IsNullOrEmpty(txtValue))
            {
                listOfData = await DevSampleService.GetCustomerByFullName(txtValue);
            }
            else
            {
                listOfData = await DevSampleService.GetCustomers();
            }
        }


        protected override async Task OnInitializedAsync()
        {
            listOfData = await DevSampleService.GetCustomers();
            listOfData.ForEach(item =>
            {
                editCache[item.Id] = (false, item);
            });
            options = listOfData.Select(s => s.CustFirstName + " " + s.CustLastName).ToList();
        }

        private async void HandleOk(MouseEventArgs e)
        {
            await DevSampleService.InsertCustomer(tempInsert);
            await LoadData();
            listOfData.ForEach(item =>
            {
                editCache[item.Id] = (false, item);
            });

            //clear record
            tempInsert = new DevSample();

            Console.WriteLine(e);
            visible = false;
        }

        private void HandleCancel(MouseEventArgs e)
        {
            Console.WriteLine(e);
            visible = false;
        }
    }
}
