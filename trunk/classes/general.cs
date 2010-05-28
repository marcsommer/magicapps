using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// class used to hold values that all forms access

    public class general
    {
        public static project actualProject;
        public static table actualTable;
        public static String templateSelected;
        public static String templateSelectedFullUri;

        public static String projectTemplateSelected;
        public static String projectTemplateSelectedFullUri;

        public static String targetDirectory;

        // if we order fields when scanning metadata
        public static bool orderFields=false;

        // we have indexed files ?
        public static bool filesIndexed = false;
    }
