using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace PowderClone
{
    class Powder
    {
        public int x = 0;
        public int y = 0;

        public bool IsSolid = false;

        public Color PowderColor = Color.Gray;

        public virtual void Update()
        {
            MoveY(2);
        }
        public void InternalUpdate()
        {
            Update();

            //more logic could go here
        }

        public void MoveY(int distance)
        {
            try
            {
                if (distance == 0) return;

                IEnumerable<Powder> PossibleObstacles;
                if (distance > 0)//Check if distance is positive (downwards)
                {
                    PossibleObstacles = Simulator.Powders.Where(c =>//Go through all powders and run checks:
                        c.x == x//Make sure we are on the same x level.
                        && y < c.y//Make sure that the y value is above ours (as we are moving downwards)
                        && y + distance >= c.y//Make sure that the y value is below or equal to our value + the distance we are travelling
                        && !c.Equals(this));//Make sure we dont include ourselves in the collision check
                }
                else
                {
                    PossibleObstacles = Simulator.Powders.Where(c =>//Go through all powders and run checks:
                        c.x == x//Make sure we are on the same x level.
                        && y > c.y//Make sure that the y value is below ours (as we are moving upwards)
                        && y + distance <= c.y//Make sure that the y value is below or equal to our value + the distance we are travelling
                        && !c.Equals(this));//Make sure we dont include ourselves in the collision check
                }

                if (PossibleObstacles.Any())
                {
                    //are we positive or negative?
                    if (distance > 0)
                    {
                        //the smallest number is the closest

                        //doing a OrderBy.ToList[0] is the fastest according to performance analysis
                        var nearest = PossibleObstacles.OrderBy(c => c.y).ToList()[0];

                        y = nearest.y - 1 - distance;
                    }
                    else
                    {
                        ////the biggest number is the closest

                        //doing a OrderBy.ToList[0] is the fastest according to performance analysis
                        var nearest = PossibleObstacles.OrderByDescending(c => c.y).ToList()[0];

                        y = nearest.y + 1 + (distance * -1);
                    }
                }


                //sanity checks for map edges
                if (distance > 0)
                {
                    for (int i = 0; i < distance; i++)
                    {
                        if (y + i >= ROpt.OutputHeight - 1)
                        {
                            y = ROpt.OutputHeight - 1;
                            return;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i > distance; i--)
                    {
                        if (y + i <= 0)
                        {
                            y = 0;
                            return;
                        }
                    }
                }

                //if we haven't returned by now, we are good to move normally.
                y = y + distance;
            }
            catch(InvalidOperationException) { Debug.WriteLine("MoveY failed with InvOP at distance " + distance);}

        }

        public void MoveX(int distance)
        {
            try
            {
                if (distance == 0) return;

                IEnumerable<Powder> PossibleObstacles;
                if (distance > 0)//Check if distance is positive (downwards)
                {
                    PossibleObstacles = Simulator.Powders.Where(c =>//Go through all powders and run checks:
                        c.y == y//Make sure we are on the same x level.
                        && !c.Equals(this)//Make sure we dont include ourselves in the collision check
                        && x < c.x//Make sure that the y value is above ours (as we are moving downwards)
                        && x + distance >= c.x);//Make sure that the y value is below or equal to our value + the distance we are travelling
                }
                else
                {
                    PossibleObstacles = Simulator.Powders.Where(c =>//Go through all powders and run checks:
                        c.y == y//Make sure we are on the same x level.
                        && !c.Equals(this)//Make sure we dont include ourselves in the collision check
                        && x > c.x//Make sure that the y value is below ours (as we are moving upwards)
                        && x + distance <= c.x);//Make sure that the y value is below or equal to our value + the distance we are travelling
                }

                if (PossibleObstacles.Any())
                {
                    //are we positive or negative?
                    if (distance > 0)
                    {
                        //the smallest number is the closest

                        //doing a OrderBy.ToList[0] is the fastest according to performance analysis
                        var nearest = PossibleObstacles.OrderBy(c => c.x).ToList()[0];

                        x = nearest.x - 1 - distance;
                    }
                    else
                    {
                        ////the biggest number is the closest

                        //doing a OrderBy.ToList[0] is the fastest according to performance analysis
                        var nearest = PossibleObstacles.OrderByDescending(c => c.x).ToList()[0];

                        x = nearest.x + 1 + (distance * -1);
                    }
                }


                //sanity checks for the map edge
                if (distance > 0)
                {
                    for (int i = 0; i < distance; i++)
                    {
                        if (x + i >= ROpt.OutputWidth - 1)
                        {
                            x = ROpt.OutputWidth - 1;
                            return;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i > distance; i--)
                    {
                        if (x + i <= 0)
                        {
                            x = 0;
                            return;
                        }
                    }
                }

                //if we haven't returned by now, we are good to just move normally.
                x = x + distance;
            }
            catch (InvalidOperationException) { Debug.WriteLine("MoveX failed with InvOP at distance " + distance); }

        }

        public bool OnSolid()
        {
            if (y + 1 >= ROpt.OutputHeight - 1)
            {
                return true;
            }

            var powder = Simulator.Powders.FirstOrDefault(c => c.y == y + 1);
            if (powder != null)
            {
                if (powder is Anchored) return true;
                return Simulator.Powders.First(c => c.y == y + 1).OnSolid();
            }

            return false;
        }
    }
}
