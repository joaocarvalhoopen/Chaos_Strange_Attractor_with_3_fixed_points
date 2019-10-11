using System;
using System.Text;

public class Color
{
    public double red;
    public double green;
    public double blue;

    public Color(double red, double green, double blue){
        this.red   = red;
        this.green = green;
        this.blue  = blue;
    }

    // Equality between two numbers based on < then Epsilon.
    public static bool equalsEpsilon(double a, double b){
        if ( Math.Abs(a - b) < Constants.Epsilon)
            return true;
        else
            return false;
    }

    // Normal functions for equality.
    public override bool Equals(object other){
        return Equals(other as Tuple);
    }

    public bool Equals(Color other){
        
        if (other == null)
            return false;

        return equalsEpsilon(this.red, other.red) && 
               equalsEpsilon(this.green, other.green) &&
               equalsEpsilon(this.blue, other.blue);
    }

    public override int GetHashCode(){
        int hash = 13;
        hash = (hash * 7) + red.GetHashCode();
        hash = (hash * 7) + green.GetHashCode();
        hash = (hash * 7) + blue.GetHashCode();
        return hash;
    }

    public static bool operator ==(Color item1, Color item2){
        if (object.ReferenceEquals(item1, item2)) { return true; }
        if ((object)item1 == null || (object)item2 == null) { return false; }
        return item1.Equals(item2);
    }

    public static bool operator !=(Color item1, Color item2){
        return !(item1 == item2);
    }

    // Operators.
    public static Color operator +(Color item1, Color item2){
        return new Color(item1.red   + item2.red,
                         item1.green + item2.green,
                         item1.blue  + item2.blue );
    }

    public static Color operator -(Color item1, Color item2){
        return new Color(item1.red   - item2.red,
                         item1.green - item2.green,
                         item1.blue  - item2.blue );
    }

    public static Color operator *(Color item1, double scalar){
        return new Color(item1.red   * scalar,
                         item1.green * scalar,
                         item1.blue  * scalar );
    }

    public static Color operator *(Color item1, Color item2){
        return new Color(item1.red   * item2.red,
                         item1.green * item2.green,
                         item1.blue  * item2.blue );
    }

    public static Color operator /(Color item1, double scalar){
        return new Color(item1.red / scalar,
                         item1.green / scalar,
                         item1.blue / scalar );
    }

    private string toPpmColor(double colorValue){
        if (colorValue < 0)
            return "0";
        else if (colorValue > 1)
            return "255";
        else{
            int scaledColorValue = (int)(colorValue * 255 + 0.5); 
            return string.Format("{0}", scaledColorValue);
        }
    }

    public string toPpmString(){
        StringBuilder sb = new StringBuilder(12);
        sb.Append(this.toPpmColor(this.red));
        sb.Append(" ");
        sb.Append(this.toPpmColor(this.green));
        sb.Append(" ");
        sb.Append(this.toPpmColor(this.blue));
        return sb.ToString();
    }

    public void setColor(Color c){
        this.red   = c.red;
        this.green = c.green;
        this.blue  = c.blue;
    }
}

