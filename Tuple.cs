using System;

public class Tuple
{
    public double x;
    public double y;
    public double z;
    public double w;

    public Tuple(double x, double y, double z, double w){
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public static Tuple Point(double x, double y, double z){
        return new Tuple(x, y, z, 1);
    }
    
    public static Tuple Vector(double x, double y, double z){
        return new Tuple(x, y, z, 0);
    }

    public bool isPoint(){
        bool res = false;
        if (this.w == 1)
            res = true;
        return res; 
    }

    public bool isVector(){
        bool res = false;
        if (this.w == 0)
            res = true;
        return res; 
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

    public bool Equals(Tuple other){
        
        if (other == null)
            return false;

        return equalsEpsilon(this.x, other.x) && 
               equalsEpsilon(this.y, other.y) &&
               equalsEpsilon(this.z, other.z) && 
               equalsEpsilon(this.w, other.w);
    }

    public override int GetHashCode(){
        int hash = 13;
        hash = (hash * 7) + x.GetHashCode();
        hash = (hash * 7) + y.GetHashCode();
        hash = (hash * 7) + z.GetHashCode();
        hash = (hash * 7) + w.GetHashCode();
        return hash;
    }

    public static bool operator ==(Tuple item1, Tuple item2){
        if (object.ReferenceEquals(item1, item2)) { return true; }
        if ((object)item1 == null || (object)item2 == null) { return false; }
        return item1.Equals(item2);
    }

    public static bool operator !=(Tuple item1, Tuple item2){
        return !(item1 == item2);
    }

    // Operators.
    public static Tuple operator +(Tuple item1, Tuple item2){
        return new Tuple(item1.x + item2.x,
                         item1.y + item2.y,
                         item1.z + item2.z,
                         item1.w + item2.w );
    }

    public static Tuple operator -(Tuple item1, Tuple item2){
        return new Tuple(item1.x - item2.x,
                         item1.y - item2.y,
                         item1.z - item2.z,
                         item1.w - item2.w );
    }

    public static Tuple operator -(Tuple item1){
        return new Tuple(-item1.x,
                         -item1.y,
                         -item1.z,
                         -item1.w );
    }

    public static Tuple operator *(Tuple item1, double scalar){
        return new Tuple(item1.x * scalar,
                         item1.y * scalar,
                         item1.z * scalar,
                         item1.w * scalar );
    }

    public static Tuple operator /(Tuple item1, double scalar){
        return new Tuple(item1.x / scalar,
                         item1.y / scalar,
                         item1.z / scalar,
                         item1.w / scalar );
    }


    public double magnitude(){
        return Math.Sqrt( this.x * this.x +
                          this.y * this.y +
                          this.z * this.z +
                          this.w * this.w ) ; 
    }

    public Tuple normalize(){
        double mag = this.magnitude();
        return new Tuple(this.x / mag,
                         this.y / mag,
                         this.z / mag,
                         this.w / mag ); 
    }

    public double dot(Tuple b){
        return this.x * b.x +
               this.y * b.y +
               this.z * b.z +
               this.w * b.w; 
    }

    public Tuple cross(Tuple b){
        return Tuple.Vector(this.y * b.z - this.z * b.y,
                            this.z * b.x - this.x * b.z,
                            this.x * b.y - this.y * b.x ); 
    }


}

