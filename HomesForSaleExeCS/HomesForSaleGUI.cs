using System;
using System.Windows.Forms;
using RealEstateLibraryCS;

namespace HomesForSaleExeCS
{
    public partial class HomesForSaleGUI : Form
    {
        private int id;
        private string currentFile;
        private EstateManager estateManager;

        public HomesForSaleGUI()
        {
            InitializeComponent();
            InitializeFields();
        }

        private void InitializeFields()
        {
            estateManager = new EstateManager();
            landSizeTBox.Enabled = false;
            floorTBox.Enabled = false;
            rentalRBtn.Checked = true;
            id = 1;  
            currentFile = null;
            typeOfEstateCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            searchEstateCBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            RealEstateObject objectToAdd;

            //Create the type of object according to what type of estate it is
            string typeOfEstate = typeOfEstateCBox.GetItemText(typeOfEstateCBox.SelectedItem);
            switch (typeOfEstate)
            {
                case "WareHouse":
                    objectToAdd = new Warehouse();
                    if (landSizeTBox.Text.ToString() != "")
                    {
                        Warehouse warehouse = (Warehouse)objectToAdd;
                        warehouse.LandSizeInSquareMeters = Int32.Parse(landSizeTBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please enter land size", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "Store":
                    objectToAdd = new Store();
                    break;
                case "Apartment":
                    objectToAdd = new Apartment();
                    if (floorTBox.Text.ToString() != "")
                    {
                        Apartment apartment = (Apartment)objectToAdd;
                        apartment.Floor = floorTBox.Text;
                    }
                    else
                    {
                        MessageBox.Show("Please enter floor", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "Villa":
                    objectToAdd = new Villa();
                    break;
                case "RowHouse":
                    objectToAdd = new RowHouse();
                    break;
                default:
                    MessageBox.Show("Please choose type of estate", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            SetLegalForm(objectToAdd);

            //Check so the correct fields are filled in,
            //then add the object to the list
            if (CheckFields())
            {
                MakeObjectToAdd(objectToAdd);
            }
            else
            {
                MessageBox.Show("Please enter text in all fields", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            objectToAdd.Id = id;

            estateManager.Add(objectToAdd);
            ShowAllObjectsInListBox();
            ClearFields();
            id++;
        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            //If no object is chosen
            if(objectsLView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please choose an object in the list to change");
                return;
            }

            //Get the ID of the selected object so we can change the corresponding object
            //in the list
            int idOfSelected = Int32.Parse(objectsLView.SelectedItems[0].SubItems[0].Text);
            RealEstateObject objectToAdd;

            //Create the type of object according to what type of estate it is
            string typeOfEstate = typeOfEstateCBox.GetItemText(typeOfEstateCBox.SelectedItem);
            switch (typeOfEstate)
            {
                case "WareHouse":
                    objectToAdd = new Warehouse();
                    if (landSizeTBox.Text.ToString() != "")
                    {
                        Warehouse warehouse = (Warehouse)objectToAdd;
                        warehouse.LandSizeInSquareMeters = Int32.Parse(landSizeTBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Please enter land size", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "Store":
                    objectToAdd = new Store();
                    break;
                case "Apartment":
                    objectToAdd = new Apartment();
                    if (floorTBox.Text.ToString() != "")
                    {
                        Apartment apartment = (Apartment)objectToAdd;
                        apartment.Floor = floorTBox.Text;
                    }
                    else
                    {
                        MessageBox.Show("Please enter floor", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "Villa":
                    objectToAdd = new Villa();
                    break;
                case "RowHouse":
                    objectToAdd = new RowHouse();
                    break;
                default:
                    MessageBox.Show("Please choose type of estate", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            SetLegalForm(objectToAdd);
            
            //Check so the correct fields are filled in,
            //then add/ replace with the new edited object to the list
            if (CheckFields())
            {
                MakeObjectToAdd(objectToAdd);
            }
            else
            {
                MessageBox.Show("Please enter text in all fields", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            objectToAdd.Id = idOfSelected;

            for (int i = 0; i < estateManager.Count; i++)
            {
                if (estateManager.GetAt(i).Id == idOfSelected)
                {
                    estateManager.ChangeAt(objectToAdd, i);
                }
            }

            ShowAllObjectsInListBox();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            estateManager.DeleteAt(objectsLView.SelectedIndices[0]);
            ClearFields();
            ShowAllObjectsInListBox();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            objectsLView.Items.Clear();
            string citySearch = searchCityTBox.Text.ToUpper();
            string typeOfEstateSearch = searchEstateCBox.Text.ToUpper();

            for (int i = 0; i < estateManager.Count; i++)
            {
                RealEstateObject obj = estateManager.GetAt(i);
                string city = obj.Address.City.ToUpper();
                string typeOfEstate = obj.TypeOfEstate.ToUpper();

                if (citySearch == city && typeOfEstateSearch == typeOfEstate)
                {
                    AddObjectToList(obj);
                }
            }
        }

        private void AddObjectToList(RealEstateObject obj)
        {
            ListViewItem lvi = new ListViewItem(obj.Id.ToString());
            lvi.SubItems.Add(obj.Address.Country);
            lvi.SubItems.Add(obj.Address.City);
            lvi.SubItems.Add(obj.Address.Street);
            lvi.SubItems.Add(obj.TypeOfEstate);

            objectsLView.Items.Add(lvi);
        }

        private void TypeOfEstateCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string typeOfEstate = typeOfEstateCBox.GetItemText(typeOfEstateCBox.SelectedItem);

            //Enable and disable fields according to type of estate chosen
            switch (typeOfEstate)
            {
                case "WareHouse":
                    landSizeTBox.Enabled = true;
                    floorTBox.Enabled = false;
                    floorTBox.Text = "";
                    break;
                case "Apartment":
                    floorTBox.Enabled = true;
                    landSizeTBox.Enabled = false;
                    landSizeTBox.Text = "";
                    break;
                default:
                    landSizeTBox.Enabled = false;
                    floorTBox.Enabled = false;
                    landSizeTBox.Text = "";
                    floorTBox.Text = "";
                    break;
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ShowAllObjectsInListBox()
        {
            objectsLView.Items.Clear();
            for(int i = 0; i < estateManager.Count; i++)
            {
                AddObjectToList(estateManager.GetAt(i));
            }
        }

        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            ShowAllObjectsInListBox();
        }

        /// <summary>
        /// Populate the fields in the GUI with the corresponding item clicked on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObjectsLView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in objectsLView.SelectedItems)
            {
                int idOfSelected = Int32.Parse(item.SubItems[0].Text);

                for (int i = 0; i < estateManager.Count; i++)
                {
                    if (estateManager.GetAt(i).Id == idOfSelected)
                    {
                        PopulateFields(i);
                    }
                }
            }
        }

        private void MnuFileExit_Click(object sender, EventArgs e)
        {
            if (estateManager.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Do you wish to save your list before exiting?"
                   , "Save work...", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (currentFile != null)
                    {
                        estateManager.BinarySerialize(currentFile);
                    }
                    else
                    {
                        SaveAs();
                    }
                }
            }
            Application.Exit();
        }

        private void MnuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void MnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                estateManager.BinaryDeSerialize(ofd.FileName);
            }
            ShowAllObjectsInListBox();

            id = (estateManager.GetAt(estateManager.Count - 1).Id) + 1;
        }

        private void MnuFileSave_Click(object sender, EventArgs e)
        {
            if(currentFile != null)
            {
                estateManager.BinarySerialize(currentFile);
            }
            else
            {
                SaveAs();
            }
        }

        private void MnuFileNew_Click(object sender, EventArgs e)
        {
            if (estateManager.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Do you wish to save your list before creating a new one?"
                , "Save work...", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (currentFile != null)
                    {
                        estateManager.BinarySerialize(currentFile);
                    }
                    else
                    {
                        SaveAs();
                    }
                }
            }
            ClearFields();
            InitializeFields();
            objectsLView.Items.Clear();
        }

        private void InfoBtn_Click(object sender, EventArgs e)
        {
            if (objectsLView.SelectedItems.Count > 0)
            {
                ListViewItem item = objectsLView.SelectedItems[0];
                int idOfSelected = Int32.Parse(item.SubItems[0].Text);
                for (int i = 0; i < estateManager.Count; i++)
                {
                    if (estateManager.GetAt(i).Id == idOfSelected)
                    {
                        MessageBox.Show(estateManager.GetAt(i).ToString(), "Info");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose an object in the list");
            }
        }

        private void SetLegalForm(RealEstateObject objectToAdd)
        {
            string legalFormType = GetCheckedRadio(newObjectBox).Text;
            switch (legalFormType)
            {
                case "Tenement":
                    objectToAdd.SetLegalForm(LegalForm.Tenement);
                    break;
                case "Rental":
                    objectToAdd.SetLegalForm(LegalForm.Rental);
                    break;
                case "Ownership":
                    objectToAdd.SetLegalForm(LegalForm.Ownership);
                    break;
            }
    
        }

        private void MakeObjectToAdd(RealEstateObject objectToAdd)
        {
            Address address = new Address();
            address.Country = countryTBox.Text;
            address.City = cityTBox.Text;
            address.Street = streetTBox.Text;
            address.ZipCode = zipCodeTBox.Text;

            objectToAdd.Address = address;
            objectToAdd.Price = Int32.Parse(priceTBox.Text);
            objectToAdd.NumberOfRooms = roomsTBox.Text;
            objectToAdd.TypeOfEstate = typeOfEstateCBox.Text;
        }

        private void ClearFields()
        {
            typeOfEstateCBox.SelectedIndex = -1;
            roomsTBox.Text = "";
            priceTBox.Text = "";
            landSizeTBox.Text = "";
            streetTBox.Text = "";
            cityTBox.Text = "";
            zipCodeTBox.Text = "";
            floorTBox.Text = "";
            countryTBox.Text = "";
        }

        private bool CheckFields()
        {
            if (roomsTBox.Text.ToString() != "" && priceTBox.Text.ToString() != ""
                && streetTBox.Text.ToString() != "" && cityTBox.Text.ToString() != ""
                && zipCodeTBox.Text.ToString() != "")
            {
                return true;
            }
            return false;
        }

        private void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                estateManager.BinarySerialize(sfd.FileName);
                currentFile = sfd.FileName;
            }
        }

        private void PopulateFields(int index)
        {
            RealEstateObject obj = estateManager.GetAt(index);
            typeOfEstateCBox.Text = obj.TypeOfEstate;
            roomsTBox.Text = obj.NumberOfRooms.ToString();
            priceTBox.Text = obj.Price.ToString();

            LegalForm legalForm = obj.GetLegalForm();
            switch (legalForm)
            {
                case LegalForm.Rental:
                    rentalRBtn.PerformClick();
                    break;
                case LegalForm.Tenement:
                    tenenmentRButton.PerformClick();
                    break;
                case LegalForm.Ownership:
                    ownerShipRBtn.PerformClick();
                    break;
            }

            if (obj is Warehouse)
            {
                Warehouse wareHouse = (Warehouse)obj;
                landSizeTBox.Text = wareHouse.LandSizeInSquareMeters.ToString();
            }

            if (obj is Apartment)
            {
                Apartment apartment = new Apartment();
                apartment = (Apartment)obj;
                floorTBox.Text = apartment.Floor.ToString();
            }

            streetTBox.Text = obj.Address.Street;
            cityTBox.Text = obj.Address.City;
            zipCodeTBox.Text = obj.Address.ZipCode;
            countryTBox.Text = obj.Address.Country;
        }

        RadioButton GetCheckedRadio(Control container)
        {
            foreach (var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;

                if (radio != null && radio.Checked)
                {
                    return radio;
                }
            }

            return null;
        }
    }
}
