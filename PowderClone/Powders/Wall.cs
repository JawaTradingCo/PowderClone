using System.Drawing;

namespace PowderClone
{
    class Wall : Powder, Flammable, Anchored
    {
        public Wall()
        {
            SetPos(5, 10);
            SetColor(Color.SlateGray);

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
