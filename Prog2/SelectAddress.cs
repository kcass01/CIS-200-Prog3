// Program 3
// CIS 200-76
// Fall 2017
// Due: 11/13/2017
// By: D7010

// File: SelectAddress.cs
// This class creates a GUI to select an address to edit.
// It offers a dropdown to select the address, with all details listed
// out in read only text boxes. The previous and next buttons can also
// select and address.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class SelectAddress : Form
    {
        //constructor
        //preconditions: list of addresses passed
        //postconditions: form prepared for address selection
        public SelectAddress(List<Address> addressList)
        {
            InitializeComponent();
            selectionList = addressList;
            //checks if list contains address
            if (selectionList.Count > 0)
            {
                //automatically populates with first entry
                PopulateForm(0);
                foreach(Address a in selectionList)
                {
                    selectAddressComboBox.Items.Add(a.Name);
                }
                //sets combo box index to first address
                selectAddressComboBox.SelectedIndex = 0;
            }
            //if there are no addresses in the passed list
            else
            { 
                MessageBox.Show("No addresses Found!");
                //disables both buttons
                nextButton.Enabled = false;
                editButton.Enabled = false;
            }
        }
        //field variable to hold current address selection index
        private int addressIndex;
        //field variable to hold address list\
        List<Address> selectionList;

        //method to pupulate form based on selected index
        //preconditions: index in list of addresses passed
        //postconditions: form updated
        public void PopulateForm(int index)
        {
            addressLineOneTextBox.Text = selectionList[index].Address1;
            //checks if line two exists
            if (!string.IsNullOrWhiteSpace(selectionList[index].Address2))
                addressLineTwotextBox.Text = selectionList[index].Address2;
            else
                addressLineTwotextBox.Text = "";
            cityTextBox.Text = selectionList[index].City;
            stateTextBox.Text = selectionList[index].State;
            zipTextBox.Text = selectionList[index].Zip.ToString("D5");


            //if no more entries before, grays out button
            if (addressIndex == 0)
            {
                previousButton.Enabled = false;
            }
            //if not first entry, re-enables previous button
            else
            {
                previousButton.Enabled = true;
            }
            //if no more entries before, grays out button
            if (addressIndex == selectionList.Count - 1)
            {
                nextButton.Enabled = false;
            }
            //if not last entry, enables next button
            else
            {
                nextButton.Enabled = true;
            }
        }

        //method to return address list, 
        //preconditions: list passed to form
        //postconditions: updated list returned
        public List<Address> ReturnAddresses
        {
            get
            {
                return selectionList;
            }
        }

        //event handler for previous
        //preconditions: list of addresses exists
        //postconditions: previous entry in list displayed
        private void previousButton_Click(object sender, EventArgs e)
        {
            //enable next button
            nextButton.Enabled = true;
            addressIndex--;
            //populate form
            PopulateForm(addressIndex);
            //change combo box to current entry
            selectAddressComboBox.SelectedIndex = addressIndex;
        }

        //event handler for next
        //preconditions: list of addresses exists
        //postconditions: next entry in list displayed
        private void nextButton_Click(object sender, EventArgs e)
        {
            //enabled previous button
            previousButton.Enabled = true;
            addressIndex++;
            PopulateForm(addressIndex);
            //change combo box to current entry
            selectAddressComboBox.SelectedIndex = addressIndex;
        }

        //event handler for edit button
        //preconditions: address is selected
        //postcondition: passed to be edited
        private void editButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //property to return selected index
        public int AddressIndex
        {
            //precondition: list of addresses exists
            //postconditions: selected index returned
            get
            {
                return addressIndex;
            }
        }

        //event for cancel button
        //precondition: none
        //postcondition: editing canceled
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //event for selecting a new item in the address combo box
        //preconditions: user selects value in combo box
        //postconditions: form is updated to show details for new selection
        private void selectAddressComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addressIndex = selectAddressComboBox.SelectedIndex;
            PopulateForm(addressIndex);
        }
    }
}
