using System.Windows.Forms;
using ZigZag.GameEngine.Statistic;

namespace ZigZag.DesktopUI.GameForms
{
    public partial class RatingForm : Form
    {
        public RatingForm()
        {
            InitializeComponent();

            var statistic = new GameStatistic();
            this.RatingDataGridView.Rows.Add();
            var row = new DataGridViewRow();           
            var index = 0;
            this.RatingDataGridView.RowCount = 1;
            if (statistic.Top.Count != 0)
            {
                this.RatingDataGridView.RowCount = statistic.Top.Count;
                foreach (var top in statistic.Top)
                {
                    this.RatingDataGridView.Rows[index].Cells[0].Value = (index + 1).ToString();
                    this.RatingDataGridView.Rows[index].Cells[1].Value = top.Name;
                    this.RatingDataGridView.Rows[index].Cells[2].Value = top.Score.ToString();
                    index++;
                }
            }
        }
    }
}
