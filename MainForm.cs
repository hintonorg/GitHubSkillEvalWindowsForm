using Octokit;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitHubSkillEval
{
    public partial class MainForm : Form
    {
        private static GitHubClient client;
        private static string MyOrganization;

        public MainForm()
        {
            InitializeComponent();

            string GetHubIdentity;
            Credentials credentials;

            GetHubIdentity = "GitHubSkillEval";
            MyOrganization = "hintonorg";

            try
            {
                client = new GitHubClient(new ProductHeaderValue(GetHubIdentity));

                //credentials = new Credentials("133e3554909b83a8a81364661fe822e60d8ff466");    //My personal access token.  Does not work if I update GitHub with a new Id.
                credentials = new Credentials("dwaynehinton", "Mygithubpwd1");                  //Login name and password
                client.Credentials = credentials;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task ScanForLicenses()
        {
            int iCnt = 0;

            txtList.Text = "";

            try
            {
                //Get all the repositories in the Organization.
                var Repositories = await client.Repository.GetAllForOrg(MyOrganization);
                foreach (var repo in Repositories)
                {
                    if (repo.License == null)
                    {
                        txtList.Text = txtList.Text + "*No License for the \"" + repo.Name.ToString() + "\" Repository\n\r\n\r";
                    }
                    else
                    {
                        txtList.Text = txtList.Text + repo.License.Name + " for the \"" + repo.Name.ToString() + "\" Repository\n\r\n\r";
                    }

                    iCnt++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task CreateLicenses()
        {
            string LicenseBody;
            int iCnt = 0;

            txtList.Text = "";

            //Get a MIT License
            var mitlicense = await client.Miscellaneous.GetLicense("mit");

            try
            {
                //Get all the repositories in the Organization.
                var Repositories = await client.Repository.GetAllForOrg(MyOrganization);
                foreach (var repo in Repositories)
                {
                    if (repo.License == null)
                    {
                        LicenseBody = mitlicense.Body;

                        //Change the [year], in the license body, to the current year. 
                        LicenseBody = LicenseBody.Replace("[year]", DateTime.Now.Year.ToString());

                        //Change the [fullname], in the license body, to the name of the repo.
                        LicenseBody = LicenseBody.Replace("[fullname]", repo.Name);

                        //Create a commit
                        var createChangeSet = await client.Repository.Content.CreateFile(
                                MyOrganization,
                                repo.Name,
                                "LICENSE",
                                new CreateFileRequest("File creation",
                                                      LicenseBody,
                                                      "master"));


                        txtList.Text = txtList.Text + "A \"MIT License\" was created for the \"" + repo.Name.ToString() + "\" Repository\n\r\n\r";
                    }
                    else
                    {
                        txtList.Text = txtList.Text + "Already had a \"MIT License\" for the \"" + repo.Name.ToString() + "\" Repository\n\r\n\r";
                    }

                    iCnt++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnScanForLicenses_Click(object sender, EventArgs e)
        {
            Task.Run(async () => { await ScanForLicenses(); });
        }

        private void BtnCreateLicenses_Click(object sender, EventArgs e)
        {
            Task.Run(async () => { await CreateLicenses(); });
        }
    }
}
