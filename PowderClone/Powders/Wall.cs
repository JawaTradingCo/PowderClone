using System.Drawing;

namespace PowderClone
{
    class Wall : Powder, Flammable, Anchored
    {
        public Wall()
        {
            PowderColor = Color.SlateGray;

            IsSolid = true;
        }
        public override void Update()
        {
            
        }

        public double Flammability()
        {
            return 0.25;
        }
    }
}
