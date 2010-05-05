using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// for treenode
using System.Windows.Forms;

class fieldNode : TreeNode
{

    public field campito;

    public fieldNode(field fieldx)
    {
        campito = fieldx;
        this.Text = fieldx.Name;
    }

}
