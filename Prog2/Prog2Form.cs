// Program 3
// CIS 200-76
// Fall 2017
// Due: 11/13/2017
// By: D7010

// File: Prog2Form.cs
// This class creates the main GUI for Program 2. It provides a
// File menu with About and Exit items, an Insert menu with Address and
// Letter items, and a Report menu with List Addresses and List Parcels
// items. For prog 3, an option to exit a given address and a menu to save
// and load are included. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        private UserParcelView upv; // The UserParcelView

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display. A few test addresses are
        //                added to the list of addresses
        public Prog2Form()
        {
            InitializeComponent();

            upv = new UserParcelView();
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // Newline shorthand

            MessageBox.Show($"Program 3{NL}By: D7010{NL}CIS 200-76{NL}Fall 2017",
                "About Program 3");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Insert, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result
            int zip; // Address zip code

            if (result == DialogResult.OK) // Only add if OK
            {
                if (int.TryParse(addressForm.ZipText, out zip))
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        zip); // Use form's properties to create address
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
                                   // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            reportTxt.Text = result.ToString();

            // -- OR --
            // Not using StringBuilder, just use TextBox directly

            //reportTxt.Clear();
            //reportTxt.AppendText("Addresses:");
            //reportTxt.AppendText(NL); // Remember, \n doesn't always work in GUIs
            //reportTxt.AppendText(NL);

            //foreach (Address a in upv.AddressList)
            //{
            //    reportTxt.AppendText(a.ToString());
            //    reportTxt.AppendText(NL);
            //    reportTxt.AppendText("------------------------------");
            //    reportTxt.AppendText(NL);
            //}

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Insert, Letter menu item activated
        // Postcondition: The Letter dialog box is displayed. If data entered
        //                are OK, a Letter is created and added to the list
        //                of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog
            decimal fixedCost;     // The letter's cost

            if (upv.AddressCount < LetterForm.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return; // Exit now since can't create valid letter
            }

            letterForm = new LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                if (decimal.TryParse(letterForm.FixedCostText, out fixedCost))
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        fixedCost); // Letter to be inserted
                }
               else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose(); // Best practice for dialog boxes
                                  // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Parcels menu item activated
        // Postcondition: The list of parcels is displayed in the parcelResultsTxt
        //                text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            decimal totalCost = 0;                      // Running total of parcel shipping costs
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Parcels:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                result.Append(p.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
                totalCost += p.CalcCost();
            }

            result.Append(NL);
            result.Append($"Total Cost: {totalCost:C}");

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        //object for serializating upv as a binary object
        private BinaryFormatter formatter = new BinaryFormatter();
        //stream to write file
        private FileStream upvStream;

        //event handler for the open button
        //preconditions: File, Open buttone clicked
        //postconditions: Displays interface to open a file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dialog result to hold result of open dialog
            DialogResult openFileResult;
            //string to hold open location
            string openFileName;

            using (OpenFileDialog fileOpen = new OpenFileDialog())
            {
                //set results variable to hold outcome
                openFileResult = fileOpen.ShowDialog();
                //set open path to result
                openFileName = fileOpen.FileName;

                //try block to catch various errors in file process
                try
                {
                    //first make sure user has selected to open file
                    if(openFileResult == DialogResult.OK)
                    {
                        //next check that file name is valid
                        if(!string.IsNullOrWhiteSpace(openFileName))
                        {
                            //set filestream to read stored upv
                            upvStream = new FileStream(openFileName, FileMode.Open, FileAccess.Read);

                            //deserialize stored information
                            upv = (UserParcelView) formatter.Deserialize(upvStream);
                        }
                        else
                        {
                            MessageBox.Show("Invalid File name entered", "File open error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                //catch blocks for potential errors;
                catch (SerializationException)
                {
                    MessageBox.Show("Invalid data in file, or bad data read", "File open error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(IOException)
                {
                    MessageBox.Show("Error opening file", "File open error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //close filestream
                    upvStream?.Close();
                }
            }
        }

        //event handler for the save as button
        //preconditions: File, Save as button clicked
        //postconditions: Displays interface to save a file
        private void saveASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dialog result ot hold whatever happens in save dialog
            DialogResult saveFileResult;
            //string to hold file directory
            string saveFileName;

            using (SaveFileDialog fileSave = new SaveFileDialog())
            {
                //since saving, does not require file to exist
                fileSave.CheckFileExists = false;
                //sets results variable to result of save dialog
                saveFileResult = fileSave.ShowDialog();
                //sets path to result 
                saveFileName = fileSave.FileName;
            }

            try
            {
                //if to check that user selected to save the file
                if (saveFileResult == DialogResult.OK)
                {
                    //checks if file name was actually valid
                    if(!string.IsNullOrWhiteSpace(saveFileName))
                    {
                        //use filestream to open file for write
                        upvStream = new FileStream(saveFileName,FileMode.Create, FileAccess.Write);
                        //serializer to store object information to upvstream
                        formatter.Serialize(upvStream, upv);
                    }
                    //if invalid, throws message box
                    else
                    {
                        MessageBox.Show("Invalid File name entered", "File save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            //catch errors related to an error to serialize
            catch (SerializationException)
            {
                //displayer message related to error;
                MessageBox.Show("File Could not be written", "File save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch general IO exceptions
            catch (IOException)
            {
                //display mesage box notifying user of error
                MessageBox.Show("File Could not be saved", "File save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //close file stream
                upvStream?.Close();
            }
        }

        //event handler for address button click
        //precondition: Edit address button clicked
        //postconditions: interface to edit address shown
        private void addressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SelectAddress selection = new SelectAddress(upv.AddressList);
            selection.ShowDialog();
            if(selection.DialogResult == DialogResult.OK)
            {
                int index = selection.AddressIndex;
                //variable to store selected address
                Address selected = upv.AddressAt(index);
                AddressForm editForm = new AddressForm();
                editForm.AddressName = selected.Name;
                editForm.Address1 = selected.Address1;
                if (!string.IsNullOrWhiteSpace(selected.Address2))
                    editForm.Address2 = selected.Address2;
                editForm.City = selected.City;
                editForm.State = selected.State;
                editForm.ZipText = selected.Zip.ToString("d5");
                //show edit form
                editForm.ShowDialog();
                if (editForm.DialogResult == DialogResult.OK)
                {
                    selected.Name = editForm.AddressName;
                    selected.Address1 = editForm.Address1;
                    if (!string.IsNullOrWhiteSpace(editForm.Address2))
                        selected.Address2 = editForm.Address2;
                    else
                        selected.Address2 = "";
                    selected.City = editForm.City;
                    selected.State = editForm.State;
                    selected.Zip = int.Parse(editForm.ZipText);
                    //no zip validation since already performed
                    upv.addresses[index] = selected;
                }
            }
        }
    }
}