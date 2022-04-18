using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class History
    {
        public Bitmap u;

        public bool CanUndo { get { return StackUndo.Peek() != null; } }
        public bool CanRedo { get { return StackRedo.Peek() != null; } }

        Stack<Bitmap> StackUndo = new Stack<Bitmap>();
        Stack<Bitmap> StackRedo = new Stack<Bitmap>();

        public void Undo()
        {
            if (!CanUndo)
                return;
            StackRedo.Push(StackUndo.Pop());
            u = StackUndo.Peek();
            //StackUndo.Pop();
        }

        public void Redo()
        {
            if (!CanRedo)
                return;
            StackUndo.Push(StackRedo.Pop());
            u = StackUndo.Peek();
            //StackRedo.Pop();
        }
        public void Add(Bitmap bitmap)
        {
            ResetRedo();
            StackUndo.Push(bitmap);
            //g.CopyFromScreen(g);
        }

        public void ResetRedo()
        {
            StackRedo.Clear();
        }
    }
}
