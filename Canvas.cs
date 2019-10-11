using System;
using System.Text;

public class Canvas
{
    public int width;
    public int height;
    public Color[,] buffer;

    public Canvas(int width, int height){
        this.width  = width;
        this.height = height;
        this.buffer = new Color[width, height];

        for (int x = 0; x <= buffer.GetUpperBound(0); x++){
            for (int y = 0; y <= buffer.GetUpperBound(1); y++){
                this.buffer[x, y] = new Color(0, 0, 0);
            }
        }
    }

    public void writePixel(int x, int y, Color c){
        this.buffer[x, y] = c;
    }

    public void writeAllPixel(Color c){
        for (int x = 0; x <= buffer.GetUpperBound(0); x++){
            for (int y = 0; y <= buffer.GetUpperBound(1); y++){
                Color c_tmp = this.buffer[x, y]; 
                c_tmp.setColor(c);
            }
        }
    }

    public Color pixelAt(int x, int y){
        return this.buffer[x, y];
    }
  
    public string canvasToPpm(){
        String headerStr = String.Format("P3\n{0} {1}\n255\n", this.width, this.height);
        StringBuilder strBuffer = new StringBuilder(headerStr, 1000000);
        int counter10Pixels = 0;
        for (int y = 0; y <= buffer.GetUpperBound(1); y++){
            for (int x = 0; x <= buffer.GetUpperBound(0); x++){
                Color c = this.buffer[x, y]; 
                strBuffer.Append(c.toPpmString());
                if (counter10Pixels == 5){
                    counter10Pixels = 0;
                    strBuffer.Append("\n");
                    continue;
                }
                strBuffer.Append(" ");
                counter10Pixels++;
            }
            strBuffer.Append("\n");
            counter10Pixels = 0;
        }
        return strBuffer.ToString();
    }

// @"C:\Users\Public\TestFolder\WriteText.txt"
    public void canvasToPpmFile(string filename){
         System.IO.File.WriteAllText(filename, this.canvasToPpm());
    }
}

