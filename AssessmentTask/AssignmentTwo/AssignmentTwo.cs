//A C# program that allows the user to create
//the structure using the driver code
//to which the program then computes
//for the depth of the structure.

class AssignmentTwo
{
    //Branch Constructor
    public class Branch
    {
        public List<Branch> branches;

        //Function to add a new branch
        public Branch(List<Branch> givenBranch)
        {
            branches = givenBranch;
        }
    }

    //Function to find the depth of the structure
    public static int DepthOfStructure(Branch selectedBranch)
    {
        //Base case
        if (selectedBranch == null)
            return 0;

        //Traverse all paths
        //and find the one with the
        //maximum depth
        int maxDepth = 0;
        foreach (Branch childBranches in selectedBranch.branches)
            maxDepth = Math.Max
                (maxDepth, DepthOfStructure(childBranches));

        return maxDepth + 1;
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

        //Initalize all branches
        Branch a = new Branch(new List<Branch>());
        Branch b = new Branch(new List<Branch>());
        Branch c = new Branch(new List<Branch>());
        Branch d = new Branch(new List<Branch>());
        Branch e = new Branch(new List<Branch>());
        Branch f = new Branch(new List<Branch>());
        Branch g = new Branch(new List<Branch>());
        Branch h = new Branch(new List<Branch>());
        Branch i = new Branch(new List<Branch>());
        Branch j = new Branch(new List<Branch>());
        Branch k = new Branch(new List<Branch>());

        //Create the branches' relations

        //Sub-Branches of A
        List<Branch> branchesOfA = new List<Branch>();
        branchesOfA.Add(b);
        branchesOfA.Add(c);
        a.branches = branchesOfA;

        //Sub-Branch of B
        List<Branch> branchesOfB = new List<Branch>();
        branchesOfB.Add(d);
        b.branches = branchesOfB;

        //Sub-Branches of C
        List<Branch> branchesOfC = new List<Branch>();
        branchesOfC.Add(e);
        branchesOfC.Add(f);
        branchesOfC.Add(g);        
        c.branches = branchesOfC;

        //Sub-Branch of E
        List<Branch> branchesOfE = new List<Branch>();
        branchesOfE.Add(h);
        e.branches = branchesOfE;

        //Sub-Branches of F
        List<Branch> branchesOfF = new List<Branch>();
        branchesOfF.Add(i);
        branchesOfF.Add(j);
        f.branches = branchesOfF;

        //Sub-Branch of I
        List<Branch> branchesOfI = new List<Branch>();
        branchesOfI.Add(k);
        i.branches = branchesOfI;

        //Display the depth of the structure.
        Console.WriteLine("The depth of this structure"
            + " is: "
            + DepthOfStructure(selectedBranch: a));
    }
}