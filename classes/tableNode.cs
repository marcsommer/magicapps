using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// for treenode
using System.Windows.Forms;

class tableNode : TreeNode
    {

    public table tablita;

    public tableNode(table tablex)
    {
        tablita = tablex;
        this.Text = tablex.Name  ;
    }

    }
 
