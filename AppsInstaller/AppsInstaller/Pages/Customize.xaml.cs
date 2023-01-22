﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppsInstaller.Pages
{
    /// <summary>
    /// Interaction logic for Customize.xaml
    /// </summary>
    public partial class Customize : Page
    {
        public string installLocation = "";
        public bool createShortcut = false;
        public List<string> technologies = new List<string>();

        public Customize()
        {
            InitializeComponent();
        }

        private void btnImage1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectTechnologiesEvent(chImage1, btnImage1, "python");
        }

        private void btnImage2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectTechnologiesEvent(chImage2, btnImage2, "MySql");
        }

        private void btnImage3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectTechnologiesEvent(chImage3, btnImage3, "Git");
        }

        private void btnImage4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selectTechnologiesEvent(chImage4, btnImage4, "Chrome");
        }

        //Select and UnSelect technologies
        private void selectTechnologiesEvent(CheckBox chImage, Image btnImage, string techName)
        {
            if (chImage.IsChecked == true)
            {
                btnImage.Opacity = .5;
                chImage.IsChecked = false;
                technologies.Remove(techName);
            }
            else
            {
                btnImage.Opacity = 1;
                chImage.IsChecked = true;
                technologies.Add(techName);
            }
        }

        private void btnInstallLocation_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                System.Windows.Forms.FolderBrowserDialog address = new System.Windows.Forms.FolderBrowserDialog();
                if (address.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtInstallLocation.Text = address.SelectedPath;
                    installLocation = fixAddress(address.SelectedPath);
                }
            }
        }

        private string fixAddress(string address)
        {
            string result = "";

            foreach (var item in address.Split('\\'))
            {
                if (result == "")
                    result += item;
                else
                    result += '"' + item + '"';
                result += "\\";
            }

            return result;
        }

        private void chCreateShortcut_Checked(object sender, RoutedEventArgs e)
        {
            createShortcut = (bool)chCreateShortcut.IsChecked;
        }
    }
}
