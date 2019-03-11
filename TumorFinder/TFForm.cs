using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TumorFinder
{
    public partial class TFForm : Form
    {
        public TFForm()
        {
            InitializeComponent();
            picbox_im.AllowDrop = true;
            btn_search.Enabled = false;
        }

        private Bitmap bm_im;
        int[,] array;
        int S, count1, count2, count3;

        int coord_x_mem, coord_y_mem;

        private void picbox_im_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void picbox_im_DragDrop(object sender, DragEventArgs e)
        {
            string[] path = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            picbox_im.ImageLocation = path[0];
            btn_search.Enabled = true;
        }

        //----------------------------------------------------------------------------------------
        private void btn_search_Click(object sender, EventArgs e)
        {
            picbox_im.Enabled = false;
            btn_search.Enabled = false;

            count1 = 0;
            count2 = 0;
            count3 = 0;

            bm_im = null;

            bm_im = (Bitmap)picbox_im.Image;

            //массив для перевода bitmap -> массив с 0, -1, 1 
            array = null;
            array = new int[bm_im.Width, bm_im.Height];

            //сам перевод
            for (int i = 0; i < bm_im.Width; i++)
            {
                for (int j = 0; j < bm_im.Height; j++)
                {
                    Color pix = bm_im.GetPixel(i, j);

                    if ((pix.R == 255) && (pix.G == 255) && (pix.B == 255) && (pix.A == 255))
                        array[i, j] = -1;
                    else
                        array[i, j] = 0;
                }
            }

            //стек для площади            

            Stack TumorX = new Stack();
            Stack TumorY = new Stack();

            for (int i_1 = 0; i_1 < bm_im.Width; i_1++)
            {
                for (int j_1 = 0; j_1 < bm_im.Height; j_1++)
                {
                    if(array[i_1,j_1] == -1)
                    {
                        
                        S = 1;

                        //пиксель заносится в стек
                        TumorX.Push(i_1);
                        TumorY.Push(j_1);

                        array[i_1, j_1] = 1; //1 чтобы мол прошел эту ячейку

                        //пока стек не пуст, осматриваем соседей
                        while ((TumorX.Count > 0) && (TumorY.Count > 0))
                        {

                            int x_st, y_st;

                            x_st = (int)TumorX.Pop();
                            y_st = (int)TumorY.Pop();
                            
                            for (int k = 1; k < 5; k++)
                            {
                                Neigh(x_st, y_st, k);

                                // Если соседний пиксель - Белый
                                if (array[coord_x_mem, coord_y_mem] == -1)
                                {
                                    S += 1;
                                    TumorX.Push(coord_x_mem);
                                    TumorY.Push(coord_y_mem);
                                    array[coord_x_mem, coord_y_mem] = 1; //1 чтобы мол прошел эту ячейку
                                }
                            }
                        }                        
                    }

                    if ((S > 0) && (S < 51))
                    {
                        count1 += 1;
                        S = 0;
                    }
                    if ((S > 50) && (S < 201))
                    {
                        count2 += 1;
                        S = 0;
                    }
                    if (S > 200)
                    {
                        count3 += 1;
                        S = 0;
                    }
                }
            }

            MessageBox.Show("Кол-во опухолей:\n\nНезначительные (маленькие): " + count1 +
                            "\nПод вопросом (средние): " + count2 + "\nОпасные (большие): " + count3);

            btn_search.Enabled = true;
            picbox_im.Enabled = true;
        }
        
        //кейсы для соседей
        public void Neigh(int coord_x, int coord_y, int i)
        {
            switch(i)
            {
                case 1:
                    coord_x_mem = coord_x - 1;
                    coord_y_mem = coord_y;
                    break;

                case 2:
                    coord_x_mem = coord_x + 1;
                    coord_y_mem = coord_y;
                    break;

                case 3:
                    coord_x_mem = coord_x;
                    coord_y_mem = coord_y - 1;
                    break;

                case 4:
                    coord_x_mem = coord_x;
                    coord_y_mem = coord_y + 1;
                    break;
            }
        }        
    }
}
