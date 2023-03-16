//A C# program that allows the user to create
//the structure using the driver code
//to which the program then computes
//for the depth of the structure.

class BranchStructure
{
    public class Branch
    {
        public string value;
        public List<Branch> branches;
    };

    //Function to add a new branch
    static Branch newBranch(string value)
    {
        Branch temp = new Branch();
        temp.value = value;
        temp.branches = new List<Branch>();
        return temp;
    }

    //Function to find the depth of the structure
    public static int depthOfStructure(Branch tree)
    {
        int depth = 0;
        if (tree == null)
            return depth;

        // Create a queue to traverse the structure
        Queue<Branch> q = new Queue<Branch>();

        // Enqueue whole structure to the queue
        q.Enqueue(tree);

        while (q.Count != 0)
        {
            int n = q.Count;

            //Check to see if the current branch still
            //has branches
            while (n > 0)
            {
                // Dequeue an item from queue
                Branch p = q.Peek();
                q.Dequeue();

                // Enqueue all branch of
                // the dequeued branch
                for (int i = 0; i < p.branches.Count; i++)
                    q.Enqueue(p.branches[i]);
                n--;
            }

            //Upon completing a structure level, increase
            //depth counter
            depth++;
        }
        return depth;
    }

    //Driver Code
    public static void Main(String[] args)
    {
        /* Given Structure:
                      A
                    /   \
                   B     C
                  /    / | \
                 D    E  F  G 
                     /  / \
                    H  I   J  
                       |
                       K
        */

        //Initialized the object as null
        //for error handling when user
        //decides to not create a structure
        Branch tree = null;


        //Building the structure using our
        //newBranch function
        tree = newBranch("A");
        (tree.branches).Add(newBranch("B"));
        (tree.branches).Add(newBranch("C"));
        (tree.branches[0].branches).Add(newBranch("D"));
        (tree.branches[1].branches).Add(newBranch("E"));
        (tree.branches[1].branches).Add(newBranch("F"));
        (tree.branches[1].branches).Add(newBranch("G"));
        (tree.branches[1].branches[0].branches)
            .Add(newBranch("H"));
        (tree.branches[1].branches[1].branches)
            .Add(newBranch("I"));
        (tree.branches[1].branches[1].branches)
                  .Add(newBranch("J"));
        (tree.branches[1].branches[1].branches[0].branches)
            .Add(newBranch("K"));

        //Structure exists
        if (tree != null)
        {
            Console.WriteLine("The depth of this structure"
                + " is: " + depthOfStructure(tree));
        }

        //Structure does not exist
        else
        {
            Console.WriteLine("No structure generated.");
        }
    }
}