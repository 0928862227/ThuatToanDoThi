using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _21dh114245
{
    class Program
    {
        static void Main(string[] args)
        {
            Buoi1.Run();
        }
    }

}

public static class Buoi1
{
    //khai báo biến toàn cục
    static int[,] v_arrayMatrix;
    //bậc của đỉnh
    static int[] v_degrees;
    static int n, m;
    static int[] v_outDegrees;
    static int[
        ] v_inDegrees;
    //tạo danh sách kề cho đồ thị bài 3
    static List<List<int>> v_listMatrix3 = new List<List<int>>();  // danh sách chứa từng cặp phần tử gồm nhiều giá trị 
    static int[,] v_arrayMatrix4;

    public static void Run()
    {
        //Bai1();
        //Bai2();
        Bai3();
        //Bai4();
    }
    static void Bai1()
    {
        ReadMatrix("AdjecencyMatrix.INP");
        DegreesofVertices();
        WriteMatrixBai_1("AdjecencyMatrix,OUT");
    }

    //tính bậc của các đỉnh trong đồ thị 
    static void DegreesofVertices()
    {

        v_degrees = new int[n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {

                v_degrees[i] += v_arrayMatrix[i, j];

            }
        }

    }
    /*
     * Hàm đọc file đầu vào
    File văn bản AdjecencyMatrix.INP
    - Dòng đầu tiên chứa số nguyên n là số đỉnh của đồ thị 
    - n dòng tiếp theo, mỗi dòng chứa n số biểu diễn ma trận kề của đô thị 
    link file đọc auto : ....\21dh114245\21dh114245\bin\Debug\...

    */
    static void ReadMatrix(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        //số đỉnh của đồ thị
        n = int.Parse(lines[0]);

        //ma trận kề
        v_arrayMatrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] row = lines[i + 1].Split(' ');
            for (int j = 0; j < n; j++)
            {
                v_arrayMatrix[i, j] = int.Parse(row[j]);
            }
        }
    }

    // Hàm ghi kết quả ra file
    /*
    File văn bản AdjecencyMatrix.OUT tự động sau khi run
    - Dòng đầu tiên chứa số nguyên n là số đỉnh của đồ thị 
    - Dòng thứ hai chứa n số nguyên tương ứng là bậc của các đỉnh 1.2.3..,n
    link file chứa auto : ....\21dh114245\21dh114245\bin\Debug\...

    */
    static void WriteMatrixBai_1(string out_file)
    {
        using (StreamWriter writer = new StreamWriter(out_file))
        {
            writer.WriteLine(n);

            //ghi bậc của từng đình
            for (int i = 0; i < n; i++)
            {
                writer.Write(v_degrees[i] + " ");
            }
        }
        Console.WriteLine("Successfully write file");
    }



    /* cột của ma trận tính bật vào của đỉnh 
     * dòng của ma trận tính bật ra của đỉnh
     */
    static void Bai2()
    {
        ReadMatrix("AdjecencyMatrix.INP");
        Inout_Degrees();
        WriteMatrixBai_2("BacVaoRa,OUT");
    }

    //tính bậc vào và bậc ra của từng đỉnh trong đồ thị 
    static void Inout_Degrees()
    {
        
        v_outDegrees = new int[n];
        v_inDegrees = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (v_arrayMatrix[i, j] == 1)
                {
                    v_outDegrees[i]++; 
                    v_inDegrees[j]++;
                }
            }

        }
    }



    // Hàm ghi kết quả ra file
    /*
    File văn bản BacVaoRa.OUT tự động sau khi run
    - Dòng đầu tiên chứa số nguyên n là số đỉnh của đồ thị 
    - n dòng tiếp theo, dòng thứ i gồm hai số nguyên là bậc vào, bậc ra của đỉnh i
    link file chứa auto : ....\21dh114245\21dh114245\bin\Debug\...

    */
    static void WriteMatrixBai_2(string out_file) {

        //write file
        using (StreamWriter writer = new StreamWriter(out_file))
        {
            writer.WriteLine(n);

            //ghi bậc của từng đình
            for (int i = 0; i < n; i++)
            {
                writer.WriteLine(v_inDegrees[i] + " " + v_outDegrees[i]);
            }
        }
        Console.WriteLine("Successfully write file");
    }



    /* ma trận kề : 
     * dòng thứ nhất tương ứng với đỉnh thú nhất có chứa các số đỉnh có cạnh liên thuộc tới đỉnh thứ nhất
     * dòng thứ hai ...
     */
    static void Bai3()
    {
        ReadMatrixBai_3("AdjecencyMatrix.INP");
        CountDegreeBai_3();
        WriteMatrixBai_3("AdjecencyList,OUT");
    }

    /*
     * Hàm đọc file đầu vào
    File văn bản AdjecencyList.INP
    - Dòng đầu tiên chứa số nguyên n là số đỉnh của đồ thị 
    - n dòng tiếp theo, dòng thứ i chứa một danh sách các đỉnh , mỗi đỉnh j trong danh sách tương ứng với một cạnh (i,j) của đồ thị 
    - Lưu ý: Đỉnh cô lập (đỉnh không nối với các đỉnh khác) thì dòng đó rỗng
    link file đọc auto : ....\21dh114245\21dh114245\bin\Debug\...

    */
    static void ReadMatrixBai_3(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        //số đỉnh của đồ thị
        n = int.Parse(lines[0]);

        //ma trận kề
        v_arrayMatrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            if(i + 1 < lines.Length)
            {
                string[] v_row_canhke = lines[i + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> v_List = new List<int>();
                foreach (string canhke in v_row_canhke)
                {
                    v_List.Add(int.Parse(canhke));
                }
                v_listMatrix3.Add(v_List);

            }
            else
            {
                v_listMatrix3.Add(new List<int>()); //Đỉnh cô lập 
            }
        }
    }

    static void CountDegreeBai_3()
    {
        v_degrees = new int[n];

        for (int i = 0; i < n; i++)
        {
            
             v_degrees[i] = v_listMatrix3[i].Count; //Bậc = số lượng đỉnh kề 

        }
    }


    static void WriteMatrixBai_3(string out_file)
    {

        //write file
        using (StreamWriter writer = new StreamWriter(out_file))
        {
            // ghi số đỉnh
            writer.WriteLine(n);

            // Ghi bậc của từng đỉnh 
            writer.WriteLine(string.Join(" ", v_degrees));
            
        }
        Console.WriteLine("Successfully write file");
    }


    /* 2 giá trị dòng đầu tiên là số đỉnh và số cạnh
     * từng dòng tương ứng từng cạnh ,ví dụ cạnh ab đi qua 2 đỉnh ab
     * 
     * */
    static void Bai4()
    {
        ReadMatrixBai_4("AdjecencyMatrix.INP");
        CountDegreeBai_3();
        WriteMatrixBai_3("AdjecencyList,OUT");
    }


    static void ReadMatrixBai_4(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        // Dòng đầu tiên chứa số đỉnh (n) và số cạnh (m) của cả đồ thị 
        string[] firstLine = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        n = int.Parse(firstLine[0]);
        m = int.Parse(firstLine[1]);

        //Các dòng tiếp theo chứa danh sách cạnh 
        v_arrayMatrix4 = new int[m, 2];
        for(int i = 0; i<m; i++)
        {
            string[] v_edge = lines[i + 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            v_arrayMatrix4[i, 0] = int.Parse(v_edge[0]);
            v_arrayMatrix4[i, 1] = int.Parse(v_edge[1]);
        }
    }

    static void CountDegreeBai_4()
    {
        v_degrees = new int[n];

        for (int i = 0; i < v_arrayMatrix4.GetLength(0); i++)
        {

            int u = v_arrayMatrix4[i, 0] - 1;

        }
    }

}

public static class Buoi2
{
     //khai báo biến toàn cục
    static int[,] v_arrayMatrix;
    //bậc của đỉnh
    static int[] v_degrees;
    static int n, m;
    static int[] v_outDegrees;
    static int[] v_inDegrees;
    //tạo danh sách kề cho đồ thị bài 3
    static List<List<int>> v_listMatrix3 = new List<List<int>>();  // danh sách chứa từng cặp phần tử gồm nhiều giá trị 
    static int[] v_seenEdges;

    public static void Run()
    {
        //Bai1();
        //Bai2();
        //Bai3();
        //Bai4();
    }

    class CEdge
    {
        public int U { get; set; } ;
        public int V { get; set; } ;

        public CEdge(int u, int v);
    }
    public static void ConvertToEdgeList2()
    {
        v_edges2 = new List<CEdge>();
        //tạo chuỗi không trùng phần tử 
        HashSet<string> edges = new HashSet<string>();
        for(int u = 0; u <n ; u ++)
    }
}

public static class Buoi3
{
    
    //khai báo biến toàn cục
    static int[,] v_arrayMatrix;
    //bậc của đỉnh
    static int[] v_degrees;
    static int[] v_result1
    static int n, m, s; //s là đỉnh
    static int x, y ;
    static int[] v_adjList;
    static int[] v_parent2;

    public static void Run()
    {
        //Bai1();
        //Bai2();
        //Bai3();
        //Bai4();
    }

    /*
     * Hàm đọc file đầu vào
    Dữ liệu vào: File văn bản BFS.INP
        • Dòng đầu tiên chứa hai số nguyên: 𝑛, 𝑠 tương ứng là số đỉnh của đồ thị và đỉnh 𝑠.
        • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa một danh sách các đỉnh, mỗi đỉnh 𝑗 trong danh sách tương ứng với
        một cạnh (𝑖,𝑗) của đồ thị.

    link file đọc auto : ....\21dh114245\21dh114245\bin\Debug\...

    */
    static void ReadMatrixBai_1(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        //Dòng đầu tiên chứa số đỉnh (n) và đỉnh (s)
        string[] firstLine = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        n = int.Parse(firstLine[0]); //Đọc số đỉnh
        s = int.Parse(firstLine[1]);    

        v_adjList = new List<int>[n+1];

        for (int i = 0; i < n; i++)
        {
            v_adjList[i] = new List<int>();
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                string[] parts = lines[i].Split();
                foreach(string part in parts)
                {
                    v_adjList[i].Add(int Parse(part));
                }
            }
        }
    }

    //Ham BFS
    static void BreadthFirstSreachBai_1()
    {
        Queue<int> v_queue1 = new Queue<int>();
        HashSet<int> v_visited = new HashSet<int>();
        v_result1 = new List<List<int>>();
        v_queue1.Enqueue(1);
        v_visited.Add(s);

        while(v_queuel.Count > 0)
        {
            //lấy giá trị hàng đợi ra 
            int v_current = v_queuel.Enqueue();

            if(v_current != s) { v_result1.Add(v_current); }
            //Duyệt
            foreach(int ke in v_adjList[v_current])
            {
                if (!v_visited.Contains(ke))
                {
                    v_queue1.Enqueue(ke);
                    v_visited.Add(ke);  
                }
            }
        }
         
    }

    //Hàm gọi kết quả ra file
     static void WriteFileBai_1(string out_file)
    {

        //write file
        using (StreamWriter writer = new StreamWriter(out_file))
        {
            writer.WriteLine(v_result1.Count);

            // Ghi kết quả
            writer.WriteLine(string.Join(" ", v_result1));
            
        }
        Console.WriteLine("Successfully write file");
    }

     static void Bai1()
    {
        ReadMatrixBai_1("BFS.INP");
        BreadthFirstSreachBai_1();
        WriteFileBai_1("BFS,OUT");
    }


    /* 
     * Dữ liệu vào: File văn bản TimDuong.INP
        • Dòng đầu tiên chứa số 3 số nguyên: 𝑛, 𝑥, 𝑦.
        • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa một danh sách các đỉnh, mỗi đỉnh 𝑗 trong danh sách tương ứng với
        một cạnh (𝑖,𝑗) của đồ thị.
     */
    static void ReadMatrixBai_2 (string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        //Dòng đầu tiên chứa số đỉnh (n) và đỉnh (s)
        string[] firstLine = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        n = int.Parse(firstLine[0]); //Đọc số đỉnh
        x = int.Parse(firstLine[1]);    
        y = int.Parse(firstLine[2]);

        v_adjList = new List<int>[n+1];

        for (int i = 0; i < n; i++)
        {
            v_adjList[i] = new List<int>();
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                string[] parts = lines[i].Split();
                foreach(string part in parts)
                {
                    v_adjList[i].Add(int Parse(part));
                }
            }
        }
    }

    static void BreadthFirstSreachBai_2()
    {
        Queue<int> v_queue = new Queue<int>();
        bool[] v_visited = new bool[n + 1];
        v_parent2 = new int[n+1];
        
        //Khởi tạo 
        for(int i = 0; i < n; i++)
        {
            v_parent2[i] = -1; 
            v_visited[i] = false
        }

        //Bắt đầu BFS từ đỉnh n
        v_queue.Enqueue(n);
        v_visited[n] = true;
        v_parent2[n] = -1; // đỉnh xuất phát không có cha

        while(v_queuel.Count > 0)
        {
            //lấy giá trị hàng đợi ra 
            int u = v_queue.Enqueue();
            //Duyệt
            foreach(int v in v_adjList[u])
            {
                if (!v_visited[v])
                {
                    v_queue1.Enqueue(v);
                    v_visited[v] = true;
                    v_parent2[v] = u; //gán giá trị của v là u 

                    if(v = y)
                    {
                        return;
                    }
                }
            }
        }
         
    }


    /*
     * Dữ liệu ra: File văn bản TimDuong.OUT
        • Dòng đầu tiên ghi số nguyên dương 𝑘 là số đỉnh nằm trên đường đi từ đỉnh 𝑥 đến đỉnh 𝑦 (Tính luôn
            cả đỉnh 𝑥 và 𝑦).
        • Dòng thứ hai chứa 𝑘 số nguyên là các đỉnh trên đường đi từ 𝑥 đến 𝑦. 
     */
     static void WriteFileBai_2(string out_file)
    {
        int current = y;
        if (v_parent2[current] != -1)
        {
            using (StreamWriter writer = new StreamWriter(out_file))
            {
               List<int> path = new List<int>();
               //Lập duyệt mảng v_parent2
               while(current != -1)
               {
                    path.Add(current);
                    current = v_parent2[current];
               }
               //path.Bowrse();
               writer.WriteLine(path.Count);
               writer.WriteLine(string.Join(" ", path));            
            }
            Console.WriteLine("Successfully write file");
        }
        else (Console.WriteLine("Not found"))
    }
    


}
