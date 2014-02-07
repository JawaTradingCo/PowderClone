using System.Drawing;

namespace PowderClone
{
    class Wall : Powder
    {
        public Wall()
        {
            SetPos(5, 10);
            SetColor(Color.CadetBlue);

            IsSolid = true;
        }
        public override void Update()
        {
            
        }
    }
}
