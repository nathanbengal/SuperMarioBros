/* Author : David Cordle
 * Updated: June 25th 2019
 * Version: 4.5
 * Description : Code to Handle Collision Objects
 * As opposed to tuples and tracks rectangles.
 * Uses logic for hash function from stack overflow:
 * https://stackoverflow.com/questions/2733541/what-is-the-best-way-to-implement-this-composite-gethashcode
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class CollisionObject
    {
        private IGameObject Mover;
        private IGameObject Reciever;
        private Direction collisionType;

        private Type MoveType;
        private Type RecType;

        //To be independent from the rest of the code. Does not need to be known Immediately.
        private Rectangle Intersection;

        //Directions are as follows
        //Left is Zero, Right is One
        //Up is 2, Down is 3
        private enum Direction
        {
            Left,
            Right,
            Top,
            Bottom
        }

        public CollisionObject(IGameObject mov, IGameObject rec, int dir)
        {
            Mover = mov;
            Reciever = rec;
            collisionType = (Direction)dir;

            MoveType = mov.GetType();
            RecType = rec.GetType();
        }
        public CollisionObject(Type mov, Type rec)
        {
            MoveType = mov;
            RecType = rec;
        }

        public Rectangle CrossIntersection
        {
            get
            {
                return Intersection;
            }
            set
            {
                Intersection = value;
            }
        }

        public int CollisionType
        {
            get
            {
                return (int)collisionType;
            }
        }

        public Type InitiatorType
        {
            get
            {
                return MoveType;
            }
        }

        public Type RecieverType
        {
            get
            {
                return RecType;
            }
        }

        public IGameObject LeftSlot
        {
            get
            {
                return Mover;
            }
        }

        public IGameObject RightSlot
        {
            get
            {
                return Reciever;
            }
        }

        public override bool Equals(object obj)
        {
            CollisionObject comp = obj as CollisionObject;
            bool checkMove = this.InitiatorType == comp.InitiatorType;
            bool checkRec = this.RecieverType == comp.RecieverType;
            return checkMove && checkRec;
        }

        public override int GetHashCode()
        {
            //Values and logic for hash found in
            //Stack overflow.
            int hash = 17;
            hash = hash * 23 + MoveType.GetHashCode();
            hash = hash * 23 + RecType.GetHashCode();
            return hash;
        }
    }
}
