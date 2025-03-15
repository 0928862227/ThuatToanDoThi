using System;
using System.Collections;
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
            //Buoi1.Run();
            //Buoi2.Run();
            //Buoi3.Run();
            //Buoi4.Run();
            //Buoi5.Run();
            //Buoi6.Run();
            //Buoi7.Run():
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
        //Bai3();
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
    // khai báo biến toàn cục vd: m,n 
    static int n, m;
    static Dictionary<int, List<int>> vout_adjacencyList1 = new Dictionary<int, List<int>>();

    static List<List<int>> v_listMatrix2;
    static List<CEdge> v_edges2;

    static List<List<int>> v_listMatrix3;
    static List<int> reservoirs;

    static List<List<int>> v_listMatrix4;

    static List<(int, int)>[] v_MatrixGraph;

    public static void Run()
    {
        //Bai1();
        //Bai2();
        //Bai3();
        //Bai4();
        //Bai5();
    }

    
    /*
     * Bài 1 chuyển đổi thành Danh Sách Kề Convert Edge List 
     * Dữ liệu vào: File văn bản Canh2Ke.INP 
        • Dòng đầu tiên chứa hai số nguyên: 𝑛,𝑚 tương ứng là số đỉnh và số cạnh của đồ thị. 
        • 𝑚 dòng tiếp theo, mỗi dòng chứa hai đỉnh mô tả cạnh nối 2 đỉnh đ
     */
    public static void ReadMatrixBai_1(string inp_file) {
        using (StreamReader reader = new StreamReader(inp_file))
        {
            var firstLine = reader.ReadLine().Split();
            n = int.Parse(firstLine[0]);
            m = int.Parse(firstLine[1]);

            for (int i = 1; i <= n; i++)
            {
                vout_adjacencyList1[i] = new List<int>();
            }

            for (int i = 0; i < m; i++)
            {
                var edge = reader.ReadLine().Split().Select(int.Parse).ToArray();
                int u = edge[0], v = edge[1];
                vout_adjacencyList1[u].Add(v);
                vout_adjacencyList1[v].Add(u); // Đồ thị vô hướng
            }
        }

    }

    public static void ConvertEdgeListBai_1()
    {
        foreach (var key in vout_adjacencyList1.Keys)
        {
            vout_adjacencyList1[key].Sort();
        }
    }

    /*
     * Dữ liệu ra: File văn bản Canh2Ke.OUT 
        • Dòng đầu tiên chứa số đỉnh 𝑛 
        • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa một danh sách các đỉnh, mỗi đỉnh 𝑗 trong danh sách tương ứng 
        với một cạnh (𝑖,𝑗) của đồ thị (các đỉnh trong danh sách được sắp xếp từ nhỏ đến lớn). 
     */

    public static void WriteFileBai_1(string out_file)
    {
        //Ghi kết quả ra file Canh2Ke.OUT
        using (StreamWriter writer = new StreamWriter(out_file))
        {
            // ghi số đỉnh
            writer.WriteLine(n);
            
            //ghi danh sách kề 
            for(int i = 0;i <= n;i++)
            {
                if (vout_adjacencyList1[i].Count > 0)
                {
                    writer.WriteLine(string.Join(" ", vout_adjacencyList1[i]));
                }
                else
                {
                    writer.WriteLine(); //Dòng rỗng nếu không có cạnh 
                }
            }
          

        }
        Console.WriteLine("Successfully write file");

    }
   

    static void Bai1()
    {

        ReadMatrixBai_1("Canh2Ke.INP");
        ConvertEdgeListBai_1();
        WriteFileBai_1("Canh2Ke.OUT");
    }

    /*
     *Bài 2 : Chuyển danh sách kề sang danh sách cạnh 
     * Dữ liệu vào: File văn bản Ke2Canh.INP 
        • Dòng đầu tiên chứa số đỉnh 𝑛 
        • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa một danh sách các đỉnh, mỗi đỉnh 𝑗 trong danh sách tương ứng 
        với một cạnh (𝑖,𝑗) của đồ thị (các đỉnh trong danh sách được sắp xếp từ nhỏ đến lớn). 
     * */
    public static void ReadMatrixBai_2(string inp_file) {
        using (StreamReader reader = new StreamReader(inp_file))
        {
            n = int.Parse(reader.ReadLine()); // Đọc số đỉnh
            v_listMatrix2 = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                var line = reader.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    v_listMatrix2.Add(line.Split().Select(int.Parse).ToList());
                }
                else
                {
                    v_listMatrix2.Add(new List<int>()); // Đỉnh không có cạnh nào
                }
            }
        }
    }



    class CEdge
    {
        public int U { get; set; }
        public int V { get; set; }

        public CEdge(int u, int v)
        {
            U = u;
            V = v;
        }
    }
    public static void ConvertToEdgeList2()
    {
       v_edges2 = new List<CEdge>();
       //tạo chuỗi không trùng phần tử 
       HashSet<string> edges = new HashSet<string>();
       for(int u = 0; u <n ; u++)
       {
            foreach (int v in v_listMatrix2[u])
            {
                //u + 1 : đỉnh 1...5
                string edgeKey = u + 1 < v ? $"{u + 1}-{v}" : $"{v}-{u + 1}";// đảm bảo không bị trùng lặp
                if (!edges.Contains(edgeKey))
                {
                    edges.Add(edgeKey);
                    v_edges2.Add(new CEdge(u + 1, v));
                }
            }
        }
    }

    /*
     * Dữ liệu ra: File văn bản Ke2Canh.OUT 
        • Dòng đầu tiên chứa hai số nguyên: 𝑛,𝑚 tương ứng là số đỉnh và số cạnh
        • 𝑚 dòng tiếp theo, mỗi dòng chứa hai đỉnh mô tả cạnh nối 2 đỉnh đó 
     */
    public static void WriteFileBai_2(string out_file)
    {
        //Ghi kết quả ra file Canh2Ke.OUT
        using (StreamWriter writer = new StreamWriter(out_file))
        {
            // ghi số đỉnh
            writer.WriteLine($"{n} {v_edges2.Count}");
            foreach (var edge in v_edges2)
            {
                writer.WriteLine($"{edge.U} {edge.V}");
            }

        }
        Console.WriteLine("Successfully write file");

    }

    public static void Bai2()
    {
        ReadMatrixBai_2("Ke2Canh.INP");
        ConvertToEdgeList2();
        WriteFileBai_2("Ke2Canh.OUT");
    }

    /*
     * Bài 3: Viết chương trình tìm các đỉnh bồn chứa 
     * Dữ liệu vào: File văn bản BonChua.INP 
        • Dòng đầu tiên chứa số đỉnh 𝑛 của đồ thị. 
        • 𝑛 dòng tiếp theo là ma trận kề của đồ thị. 
     */
    public static void ReadMatrixBai_3(string inp_file)
    {
        using (StreamReader reader = new StreamReader(inp_file))
        {
            n = int.Parse(reader.ReadLine().Trim()); // Đọc số đỉnh, loại bỏ khoảng trắng dư

            v_listMatrix3 = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                var line = reader.ReadLine()?.Trim(); // Đọc dòng tiếp theo, loại bỏ khoảng trắng
                if (string.IsNullOrEmpty(line))
                {
                    throw new Exception($"Dòng {i + 1} bị thiếu dữ liệu trong file {inp_file}");
                }

                var row = line.Split().Select(int.Parse).ToList();

                if (row.Count != n)
                {
                    throw new Exception($"Dòng {i + 1} có {row.Count} phần tử, nhưng cần {n} phần tử");
                }

                v_listMatrix3.Add(row);
            }
        }
    }

    public static void FindReservoirs()
    {
        reservoirs = new List<int>();

        for (int i = 0; i < n; i++)
        {
            bool hasOutgoing = false;  // Kiểm tra xem đỉnh i có cung ra hay không
            bool hasIncoming = false;  // Kiểm tra xem đỉnh i có cung vào hay không

            for (int j = 0; j < n; j++)
            {
                if (v_listMatrix3[i][j] == 1) hasOutgoing = true; // Có cung ra
                if (v_listMatrix3[j][i] == 1) hasIncoming = true; // Có cung vào
            }

            if (hasIncoming && !hasOutgoing)
            {
                reservoirs.Add(i + 1); // Chuyển về đánh số từ 1
            }
        }
    }

    /*
     * Dữ liệu ra: File văn bản BonChua.OUT 
        • Dòng đầu là số nguyên dương 𝑘 là số lượng bồn chứa trong đồ thị (Ghi 0 nếu 𝐺 không có bồn chứa). 
        • Nếu 𝑘 >0 thì dòng thứ hai chứa danh sách các đỉnh bồn chứa (các đỉnh được sắp theo thứ tự từ nhỏ 
        đến lớn). 
     */
    public static void WriteFileBai_3(string out_file)
    {
        //Ghi kết quả ra file BonChua.OUT
        using (StreamWriter writer = new StreamWriter(out_file))
        {
            writer.WriteLine(reservoirs.Count);
            if (reservoirs.Count > 0)
            {
                writer.WriteLine(string.Join(" ", reservoirs));
            }
        }
        Console.WriteLine("Successfully write file");

    }

    public static void Bai3()
    {
        ReadMatrixBai_3("BonChua.INP");
        FindReservoirs();
        WriteFileBai_3("BonChua.OUT");
    }

    /*Dữ liệu vào: File văn bản ChuyenVi.INP 
        • Dòng đầu tiên chứa số đỉnh 𝑛 
        • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa một danh sách các đỉnh, mỗi đỉnh 𝑗 trong danh sách tương ứng 
          với một cung (𝑖,𝑗) của đồ thị 𝐺 (các đỉnh trong danh sách được sắp xếp từ nhỏ đến lớn). 
     */
    public static void ReadMatrixBai_4(string inp_file)
    {
        ReadMatrixBai_2(inp_file);
    }


    //ChuyenVi
    public static void ConvertToTransposeGraph()
    {
        // Tạo danh sách kề cho đồ thị chuyển vị
        List<List<int>> transposeGraph = new List<List<int>>(new List<int>[n]);

        for (int i = 0; i < n; i++)
        {
            transposeGraph[i] = new List<int>(); // Khởi tạo danh sách rỗng cho từng đỉnh
        }

        // Duyệt qua danh sách kề ban đầu và đảo hướng cạnh
        for (int u = 0; u < n; u++)
        {
            foreach (int v in v_listMatrix4[u])
            {
                transposeGraph[v - 1].Add(u + 1); // Đảo hướng từ (u → v) thành (v → u)
            }
        }

        // Sắp xếp danh sách kề của mỗi đỉnh theo thứ tự tăng dần
        for (int i = 0; i < n; i++)
        {
            transposeGraph[i].Sort();
        }

        // Lưu lại đồ thị chuyển vị vào biến toàn cục để ghi file
        v_listMatrix4 = transposeGraph;
    }

    /*
     * Dữ liệu ra: File văn bản ChuyenVi.OUT 
        • Dòng đầu tiên chứa số đỉnh 𝑛 
        • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa một danh sách các đỉnh, mỗi đỉnh 𝑗 trong danh sách tương ứng 
          với một cung (𝑖,𝑗) của đồ thị 𝐺𝑇 (các đỉnh trong danh sách được sắp xếp từ nhỏ đến lớn)
     */
    public static void WriteFileBai_4(string out_file)
    {
        using (StreamWriter writer = new StreamWriter(out_file))
        {
            writer.WriteLine(n); // Ghi số đỉnh

            for (int i = 0; i < n; i++)
            {
                if (v_listMatrix2[i].Count > 0)
                {
                    writer.WriteLine(string.Join(" ", v_listMatrix2[i]));
                }
                else
                {
                    writer.WriteLine(); // Nếu đỉnh i không có cạnh nào, ghi dòng trống
                }
            }
        }
        Console.WriteLine("Successfully wrote file: " + out_file);
    }
    public static void Bai4()
    {
        ReadMatrixBai_4("ChuyenVi.INP");
        ConvertToTransposeGraph();
        WriteFileBai_4("ChuyenVi.OUT");
    }

    /*  Bai 5: Tìm các cạnh có độ dài dài nhất và tính độ dài trung bình của các cạnh.
     * Dữ liệu vào: File văn bản TrungBinhCanh.INP 
        • Dòng đầu tiên chứa hai số nguyên: 𝑛,𝑚 tương ứng là số đỉnh và số cạnh của đồ thị. 
        • 𝑚 dòng tiếp theo, mỗi dòng chứa ba số nguyên: 𝑢,𝑣,𝑤 mô tả cạnh (𝑢,𝑣) có trọng số 𝑤. 
     */
    public static void ReadMatrixBai_5(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        // Dòng đầu tiên chứa 4 số nguyên 𝑛, 𝑚, 𝑠, 𝑡
        string[] firstLine = lines[0].Split();
        n = int.Parse(firstLine[0]); // Đọc số đỉnh
        m = int.Parse(firstLine[1]); // Đọc số cạnh


        // Khởi tạo ma trận
        v_MatrixGraph = new List<(int, int)>[n + 1];
        for (int i = 0; i < n; i++)
        {
            v_MatrixGraph[i] = new List<(int, int)>();
        }

        //𝑚 dòng tiếp theo, mỗi dòng chứa 3 số 𝑢, 𝑣, 𝑤 mô tả cung (𝑢, 𝑣) có trọng số w
        for (int i = 0; i <= m; i++)
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]); //(đầu cạnh)
            int v = int.Parse(edge[1]); //(cuối cạnh)
            int w = int.Parse(edge[2]); //trọng số 

            v_MatrixGraph[u].Add((v, w)); // Đỉnh u có kề v với trọng số w
            v_MatrixGraph[v].Add((u, w)); // Đỉnh v có kề u với trọng số w
        }

    }


    /*
     * Dữ liệu ra: File văn bản TrungBinhCanh.OUT 
        • Dòng thứ nhất chứa độ dài trung bình các cạnh (lấy 2 số lẻ thập phân) 
        • Dòng thứ 2 chứa số 𝑘 là số lượng cạnh có độ dài dài nhất. 
        • 𝑘 dòng tiếp theo 𝑘 bộ số (𝑢,𝑣,𝑤) 𝑘 cạnh dài nhất
     */
    public static void WriteMatrixBai_5(string out_file)
    {

    }

}

public static class Buoi3
{
    
    //khai báo biến toàn cục
    static int[,] v_arrayMatrix;
    //bậc của đỉnh
    static int[] v_degrees;
    static int[] v_result1;
    static int n, m, s; //s là đỉnh
    static int x, y ;
    static List<int>[] v_adjList;
    static int[] v_parent2;

    static bool v_result3;

    static bool[] v_visited4;

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
            v_visited[i] = false;
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
     
     static void WriteFileBai_2(string out_file)
    {
        int current = y;
        if (v_parent2[current] != -1)
        {
            using (StreamWriter writer = new StreamWriter(out_file))
            {
                List<int> path = new List<int>();
                //Lập duyệt mảng v_parent2
                while (current != -1)
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
        else (Console.WriteLine("Not found"));
    }
    */

    /* Bài 3: h kiểm tra đồ thị 𝐺 có liên thông không. 
     *  Dữ liệu vào: File văn bản LienThong.INP
        • Dòng đầu tiên chứa số nguyên 𝑛 là số đỉnh của đồ thị.
        • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa một danh sách các đỉnh, mỗi đỉnh 𝑗 trong danh sách tương ứng với
        một cạnh (𝑖,𝑗) của đồ thị.
     *link file đọc auto : ....\21dh114245\21dh114245\bin\Debug\...
     */
    static void ReadMatrixBai_3 (string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        //số đỉnh của đồ thị
        n = int.Parse(lines[0]);

        // Khởi tạo danh sách kề
        v_adjList = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            v_adjList[i] = new List<int>();
        }

        // Đọc các cạnh từ các dòng tiếp theo
        for (int i = 1; i <= n; i++)
        {
            string[] edges = lines[i].Split();
            foreach (string edge in edges)
            {
                int j = int.Parse(edge) - 1; // giảm đi 1 vì danh sách bắt đầu từ 0
                v_adjList[i - 1].Add(j); // thêm cạnh (i, j) vào danh sách kề
            }
        }

    }

    static bool GraphConnectedBai_3()
    {
        //Mảng đánh dấu các đỉnh đã duyệt 
        bool[] visited = new bool[n +1 ];
        int startNode = -1;

        //Hàng đợi cho BFS
        Queue<int>queue = new Queue<int> ();
        startNode = 1;  // Đỉnh bắt đầu là 1

        //Thêm đỉnh 1 vào queue
        queue.Enqueue (startNode);
        visited[startNode] = true;

        //Nếu queue còn thì lặp 
        while (queue.Count > 0)
        {
            //Đọc queue vào u 
            int u = queue.Dequeue ();

            //Duyệt đỉnh kề của u 
            foreach(int v in v_adjList[u])
            {
                if (!visited[v]) //Nếu đỉnh kề của u chưa duyệt thì duyệt 
                {
                    //Đánh dấu đã duyệt đến đỉnh kề 
                    visited[v] = true;
                    //Thêm đỉnh kề của u vào queue
                    queue.Enqueue (v);
                }
            }
        }
        // Kiểm tra xem tất cả các đỉnh có cạnh đã duyệt hay chưa 
        for(int i = 0; i < n; i++)
        {
            if(!visited[i])
                return false;
        }
        return true;
    }

    /*
     * Dữ liệu ra: File văn bản LienThong.OUT
        • Dòng duy nhất ghi ra chữ "YES" nếu đồ thị liên thông, ngược lại ghi chữ "NO"
     */
    static void WriteFileBai_3 (string out_file)
    {
        File.WriteAllText(out_file, v_result3 ? "YES" : "NO");
        Console.WriteLine(string.Join(" ", "write file 3", v_result3 ? "YES" : "NO"));
    }

    //Hàm chuẩn bị chạy bài 3
    static void Bai3()
    {
        ReadMatrixBai_3("LienThong.INP");
        v_result3 = GraphConnectedBai_3();
        WriteFileBai_3("LienThong.OUT");
    }



    /*Bai4:  Miền liên thông là tập đỉnh liên thông với nhau và nếu thêm một đỉnh khác thì không còn liên thông nữa. 
     * Hãy viết chương trình cho biết 𝐺 có bao nhiêu miền liên thông.
     *Dữ liệu vào: File văn bản DemLienThong.INP
       • Dòng đầu tiên chứa số nguyên 𝑛 là số đỉnh của đồ thị.
       • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa một danh sách các đỉnh, mỗi đỉnh 𝑗 trong danh sách tương ứng với
        một cạnh (𝑖,𝑗) của đồ thị.

     */
    static void ReadMatrixBai_4 (string imp_file)
    {
        ReadMatrixBai_3(imp_file);
    }

    static int CountConnectedComponents()
    {
        v_visited4 = new bool[n + 1]; //Khởi tạo mảng đánh dấu 
        int count = 0; // Biến đếm số miền liên thông 

        //Duyệt từng đỉnh 
        for(int i = 0; i < n; i++)
        {
            if (!v_visited4[i]) //Nếu đỉnh chưa duyệt và có ít nhất 1 cạnh 
            {
                BFS(i); //Gọi BFS để duyệt toàn bộ miền liên thông 
                count++; //Tăng số miền liên thông
            }
        }
        return count;
    }

    private static void BFS (int start)
    {
        Queue <int> queue = new Queue<int> (); 
        queue.Enqueue (start);
        v_visited4[start] = true;

        while(queue.Count > 0)
        {
            int u = queue.Dequeue ();   
            foreach(int v in v_adjList[u])
            {
                if (!v_visited4[v])
                {
                    v_visited4[v] = true;
                    queue.Enqueue(v);
                }
            }
        }
    }

    /*
     * Dữ liệu ra: File văn bản DemLienThong.OUT
        • Dòng duy nhất ghi số lượng miền liên thông tìm được
     */

    static void WriteFileBai_4(string out_file, int count)
    {
        File.WriteAllText(out_file, count.ToString());
    }


    //Hàm chuẩn bị chạy bài 4
    static void Bai4()
    {

        // 4.1. Đọc dữ liệu từ file
        ReadMatrixBai_4("DemLienThong.INP");

        // 4.2 Xử lý thuật toán BFS để kiểm tra liên thông các đỉnh
        int v_count = CountConnectedComponents();

        // 4.3.Ghi kết quả ra file
        WriteFileBai_4("LienThong.OUT",v_count);
    }


}

public static class Buoi4
{
    static int m,n,s,x,y;
    static List<int>[] v_adjList;
    static List<int> v_result;
    static bool[] v_visited;


    static List<int> v_path;
    static int[] v_parent;
    public static void Run()
    {
        //Bai1();
        //Bai2();
        
    }


    /*Hãy cho biết từ đỉnh 𝑠 có thể đi đến được những đỉnh nào (sử dụng thuật toán Depth First Search– DFS). 
     * Khi một đỉnh có nhiều đỉnh kề, thì các đỉnh được xét theo thứ tự từ nhỏ đến lớn. 
     * Dữ liệu vào: File văn bản DFS.INP
        • Dòng đầu tiên chứa hai số nguyên: 𝑛, 𝑠 tương ứng là số đỉnh của đồ thị và đỉnh 𝑠.
        • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa một danh sách các đỉnh, mỗi đỉnh 𝑗 trong danh sách tương ứng
        với một cạnh (𝑖, 𝑗) của đồ thị. 
     */

    static void ReadMatrixBai_1( string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        //Dòng đầu tiên chứa số đỉnh (n) và Startnode (s)
        string[] firstLine = lines[0].Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
        n = int.Parse(firstLine[0]); // Đọc số đỉnh
        s = int.Parse(firstLine[1]); // Đọc Startnode 

        // Khởi tạo danh sách kề
        v_adjList = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            v_adjList[i] = new List<int>();
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                string[] parts = lines[i].Split();
                foreach(string part in parts)
                {
                    v_adjList[i].Add(int.Parse(part));  
                }
            }
        }     
    }

    static void Process_DepthFirstSearchBai_1()
    {
        v_visited = new bool[n + 1];
        v_result = new List<int>();
        Stack<int> v_Stack = new Stack<int>();
        v_Stack.Push(s); //Đưa đỉnh s vào stack
        v_visited[s] = true;
       
       while(v_Stack.Count > 0)
        {
            int node = v_Stack.Pop();
            // không thêm đỉnh s vào kết quả
            if(node != s)
            {
                v_result.Add(node);
            }
            //Duyệt danh sách kề từ lớn đến nhỏ để đảm bảo DFS đi theo từ nhỏ đến lớp
            //Có thể đảo lại từ lớn đến nhỏ
            for(int i = v_adjList[node].Count - 1; i >= 0; i--)
            {
                int neighbor = v_adjList[node][i];
                if (!v_visited[neighbor])
                {
                    v_Stack.Push(neighbor);
                    v_visited[neighbor] = true; 
                }
            }
       }
    }

    /*
     * Dữ liệu ra: File văn bản DFS.OUT
        • Dòng đầu tiên ghi số 𝑘 là số lượng đỉnh tìm được.
        • Dòng thứ hai ghi 𝑘 đỉnh tìm được. 
     */
    static void WriteFileBai_1(string out_file)
    {

    }

    //Hàm chuẩn bị chạy bài 1
    static void Bai1()
    {
        ReadMatrixBai_1("DFS.INP");
        Process_DepthFirstSearchBai_1();
        WriteFileBai_1("DFS.OUT");
    }


    /*Hãy tìm đường đi từ đỉnh 𝑥 đến đỉnh 𝑦 bằng thuật toán DFS.
     * Dữ liệu vào: File văn bản TimDuongDFS.INP
        • Dòng đầu tiên chứa số 3 số nguyên: 𝑛, 𝑥, 𝑦.
        • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa một danh sách các đỉnh, mỗi đỉnh 𝑗 trong danh sách tương ứng
        với một cạnh (𝑖, 𝑗) của đồ thị. 
     */
    static void ReadMatrixBai_2(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        //Dòng đầu tiên chứa số đỉnh (n) và x,y
        string[] firstLine = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        n = int.Parse(firstLine[0]); // Đọc số đỉnh
        x = int.Parse(firstLine[1]); // Đọc x  '
        y = int.Parse(firstLine[2]); // Đọc y                          

        // Khởi tạo danh sách kề
        v_adjList = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            v_adjList[i] = new List<int>();
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                string[] parts = lines[i].Split();
                foreach (string part in parts)
                {
                    v_adjList[i].Add(int.Parse(part));
                }
            }
        }
    }

    static void Process_DepthFirstSearchBai_2()
    {
        Stack<int> stack = new Stack<int>();
        v_parent = new int[n + 1];
        v_visited = new bool[n + 1];
        v_path = new List<int>();

        stack.Push(x);
        v_visited[x] = true;
        v_parent[x] = -1; // Đỉnh đầu tiên không có cha
        //Làm rỗng đường đi giữa 2 đỉnh
        v_path.Clear();
       

        while (stack.Count > 0)
        {
            int u = stack.Pop();
            // Nếu tìm được đỉnh đích
            if (u == y)
            {
                //Dựng đường đi từ y về x
                int current = y;
                while (current != -1) //Truy ngược đích cha để lấy đường đi chính xác
                {
                    v_path.Add(current);
                    current = v_parent[current];
                }
                v_path.Reverse();
                return;
            }
            //Kiểm tra đã check chưa và duyệt kề của nó 
            foreach(int v in v_adjList[u])
            {
                if (!v_visited[u]) //đỉnh chưa check
                {
                    v_visited[v] = true; 
                    stack.Push(v);
                    v_parent[v] = u; // Lưu lại đường đi 
                }
            }
           
        }
    }

    /*
     * Dữ liệu ra: File văn bản TimDuongDFS.OUT
        • Dòng đầu tiên ghi số nguyên dương 𝑘 là số đỉnh nằm trên đường đi từ đỉnh 𝑥 đến đỉnh 𝑦 (Tính
        luôn cả đỉnh 𝑥 và 𝑦).
        • Dòng thứ hai chứa 𝑘 số nguyên là các đỉnh trên đường đi từ 𝑥 đến 𝑦. 
     */
    static void WriteFileBai_2 (string out_file)
    {

    }

    //Hàm chuẩn bị chạy bài 2
    static void Bai2()
    {
        ReadMatrixBai_2("TimDuongDFS.INP");
        Process_DepthFirstSearchBai_2();
        WriteFileBai_2("TimDuongDFS.OUT");
    }


}

public static class Buoi5
{
    static int m, n, s, x, t;
    static List<(int, int)>[] v_MatrixGraph;
    static int[] v_dist;
    static bool[] v_visited;

    static int[,] v_dist3;
    const int INF = int.MaxValue;
    static int[] v_parent;
    public static void Run()
    {
        //Bai1();
        //Bai2();
        //Bai3();
    }

    /* Bài 1: Hãy tìm đường đi ngắn nhất từ đỉnh 𝑠 đến đỉnh 𝑡 theo thuật toán Dijkstra. 
     * Dữ liệu vào: File văn bản Dijkstra.INP
        • Dòng đầu tiên chứa 4 số nguyên 𝑛, 𝑚, 𝑠, 𝑡 (tương ứng với số đỉnh , số cạnh
        và 2 đỉnh 𝑠, 𝑡 của đồ thị).
        • 𝑚 dòng tiếp theo, mỗi dòng chứa 3 số 𝑢, 𝑣, 𝑤 mô tả cung (𝑢, 𝑣) có trọng số w
     */
    static void ReadMatrixBai_1 (string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        // Dòng đầu tiên chứa 4 số nguyên 𝑛, 𝑚, 𝑠, 𝑡
        string[] firstLine = lines[0].Split();
        n = int.Parse(firstLine[0]); // Đọc số đỉnh
        m = int.Parse(firstLine[1]); // Đọc số cạnh
        s = int.Parse(firstLine[2]); // Đọc đỉnh bắt đầu
        t = int.Parse(firstLine[3]); // Đọc đỉnh kết thúc

        // Khởi tạo ma trận
        v_MatrixGraph = new List<(int, int)>[n+1];
        for (int i = 1; i < n; i++)
        {
            v_MatrixGraph[i] = new List<(int, int)>();
        }

        //𝑚 dòng tiếp theo, mỗi dòng chứa 3 số 𝑢, 𝑣, 𝑤 mô tả cung (𝑢, 𝑣) có trọng số w
        for (int i = 1; i <= m; i++)
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]); //(đầu cạnh)
            int v = int.Parse(edge[1]); //(cuối cạnh)
            int w = int.Parse(edge[2]); //trọng số 

            v_MatrixGraph[u].Add((v, w)); // Đỉnh u có kề v với trọng số w
            v_MatrixGraph[v].Add((u, w)); // Đỉnh v có kề u với trọng số w
        }
    }

    static void Dijkstral_SortedSet()
    {
        v_dist = new int[n + 1];
        v_parent = new int[n + 1];
        v_visited = new bool[n + 1];

        for(int i = 0; i <= n; i++)
        {
            v_dist[i] = INF; //đánh dấu đường đi dài nhất vô cực (chưa tìm được)
            v_parent[i] = -1; //đánh dấu chưa có đường đi
        }
        v_dist[s] = 0;
        var v_pq = new SortedSet<(int, int)>();
        v_pq.Add((0, s));

        while(v_pq.Count > 0)
        {
            var (du, u) = v_pq.Min; //Lấy giá trị nhỏ nhất 
            v_pq.Remove(v_pq.Min); //Xóa khỏi queue

            if (v_visited[u]) continue; //nếu true thì bỏ qua các dòng lệnh sau
            v_visited[u] = true;

            foreach(var (v, w) in v_MatrixGraph[u])
            {
                if (v_dist[u] + w < v_dist[v]) //Nếu tìm thấy đường đi mới, trọng số đỉnh kề mới có nhỏ hơn tổng trọng số đã lưu
                {
                    v_dist[v] = v_dist[u] + w;  // Tổng trọng số 
                    v_parent[v] = u; // Tạo mắc xích mới 
                    v_pq.Add((v_dist[v], v)); // Thêm vào hàng đợi với độ ưu tiên là khoảng cách
                }
            }
        }

    }

    //queue: lý do sài queue khi tạo ra hàng đợi, nó sẽ tự so sách và tìm ra cạnh có trọng số nhỏ nhất 
    // INF là 1 hằng số max value đánh dấu sự xuất hiện của trọng số

   /* static void Dijkstral_Queue()
    {
        v_dist = new int[n + 1];
        v_parent = new int[n + 1];
        v_visited = new bool[n + 1];

        for (int i = 0; i <= n; i++)
        {
            v_dist[i] = INF; //đánh dấu đường đi dài nhất vô cực (chưa tìm được)
            v_parent[i] = -1; //đánh dấu chưa có đường đi
        }
        v_dist[s] = 0;
        var v_pq = new PriorityQueue<(int, int)>();
        v_pq.Dequeue((0, s));

        while (v_pq.Count > 0)
        {
            int u = v_pq.Dequeue; //Lấy giá trị nhỏ nhất 
            

            if (v_visited[u]) continue; //nếu true thì bỏ qua các dòng lệnh sau
            v_visited[u] = true;

            foreach (var (v, w) in v_MatrixGraph[u])
            {
                if (v_dist[u] + w < v_dist[v]) //Nếu tìm thấy đường đi mới, trọng số đỉnh kề mới có nhỏ hơn tổng trọng số đã lưu
                {
                    v_dist[v] = v_dist[u] + w;  // Tổng trọng số 
                    v_parent[v] = u; // Tạo mắc xích mới 
                    v_pq.Dequeue((v_dist[v], v)); // Thêm vào hàng đợi với độ ưu tiên là khoảng cách
                }
            }
        }

    }
   */

    /*
     * Dữ liệu ra: File văn bản Dijkstra.OUT
        • Dòng thứ nhất ghi một số nguyên là độ dài đường đi ngắn nhất tìm được
        • Dòng thứ hai ghi các đỉnh của đường đi từ đỉnh 𝑠 đến đỉnh 𝑡 (bao gồm cả 2 đỉnh 𝑠, 𝑡)
     */
    static void WriteFileBai_1(string out_file)
    {
        using (StreamWriter sw = new StreamWriter(out_file))
        {
            if (v_dist[t] == INF) //Nếu không tìm được đỉnh
            {
                sw.WriteLine("-1");
                return;
            }
            sw.WriteLine(v_dist[t]); //In khoảng cách ngắn nhất

            List<int> path = new List<int>();
            for (int v = t; v != -1; v = v_parent[v])
                path.Add(v);

            path.Reverse();
            sw.WriteLine(string.Join(" ", path));

        }
    }


    //Hàm chuẩn bị chạy bài 1
    static void Bai1()
    {
        ReadMatrixBai_1("Dijkstra.INP");
        Dijkstral_SortedSet();
        WriteFileBai_1("Dijkstra.OUT");
    }


    /* Bài 2: Đường đi ngắn nhất qua đỉnh trung gian,  Hãy tìm đường đi ngắn từ đỉnh 𝑠 đến đỉnh 𝑡 và đường đi đó phải đi qua đỉnh 𝑥.
     * Dữ liệu vào: File văn bản NganNhatX.INP
        • Dòng đầu tiên chứa 5 số nguyên 𝑛, 𝑚, 𝑠, 𝑡, 𝑥 (tương ứng với số đỉnh (𝑛 ≤ 105), số cạnh (𝑚 ≤ 105)
        và 3 đỉnh 𝑠, 𝑡, 𝑥 của đồ thị).
        • 𝑚 dòng tiếp theo, mỗi dòng chứa 3 số 𝑢, 𝑣, 𝑤 mô tả cung (𝑢, 𝑣) có trọng số w
     */

    static void ReadMatrixBai_2(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        // Dòng đầu tiên chứa 4 số nguyên 𝑛, 𝑚, 𝑠, 𝑡
        string[] firstLine = lines[0].Split();
        n = int.Parse(firstLine[0]); // Đọc số đỉnh
        m = int.Parse(firstLine[1]); // Đọc số cạnh
        s = int.Parse(firstLine[2]); // Đọc đỉnh bắt đầu
        t = int.Parse(firstLine[3]); // Đọc đỉnh trung gian
        x = int.Parse(firstLine[4]); // Đọc đỉnh kết thúc 

        // Khởi tạo ma trận
        v_MatrixGraph = new List<(int, int)>[n + 1];
        for (int i = 0; i < n; i++)
        {
            v_MatrixGraph[i] = new List<(int, int)>();
        }

        //𝑚 dòng tiếp theo, mỗi dòng chứa 3 số 𝑢, 𝑣, 𝑤 mô tả cung (𝑢, 𝑣) có trọng số w
        for (int i = 0; i <= m; i++)
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]); //(đầu cạnh)
            int v = int.Parse(edge[1]); //(cuối cạnh)
            int w = int.Parse(edge[2]); //trọng số 

            v_MatrixGraph[u].Add((v, w)); // Đỉnh u có kề v với trọng số w
            v_MatrixGraph[v].Add((u, w)); // Đỉnh v có kề u với trọng số w
        }
    }

    private static (int[] , int[]) DijkstraBai_2 (int start)
    {
        int[] dist = new int[n + 1];
        int[] parent = new int[n + 1];
        bool[] visited = new bool[n + 1];

        for (int i = 0; i <= n; i++)
        {
            dist[i] = INF; //đánh dấu đường đi dài nhất vô cực (chưa tìm được)
            parent[i] = -1; //đánh dấu chưa có đường đi
        }
        v_dist[start] = 0;

        //Hàng đợi ưu tiên SortedSet: (khoảng cách, đỉnh)
        SortedSet<(int, int)> pq = new SortedSet<(int, int)>();
        pq.Add((0, s));

        while (pq.Count > 0)
        {
            var (du, u) = pq.Min; //Lấy đỉnh có khoảng cách nhỏ nhất 
            pq.Remove(pq.Min); //Xóa khỏi queue

            if (visited[u]) continue; //nếu true thì bỏ qua các dòng lệnh sau
            visited[u] = true; //Đánh dấu đỉnh đã xét

            foreach (var (v, w) in v_MatrixGraph[u]) // Duyệt các cạnh kề (u + v)
            {
                if (dist[u] + w < dist[v]) //Nếu tìm thấy đường đi mới, trọng số đỉnh kề mới có nhỏ hơn tổng trọng số đã lưu
                {
                    dist[v] = dist[u] + w;  // Tổng trọng số 
                    parent[v] = u; // Tạo mắc xích mới 
                    pq.Add((v_dist[v], v)); // Thêm vào hàng đợi với độ ưu tiên là khoảng cách
                }
            }
        }return (dist, parent);
    }

    //Hàm truy vết đường đi từ Đỉnh bắt đầu đến đỉnh kết thúc 
    private static void GetPath(int start, int end, int[] parent, List<int> path)
    {
        List<int> temp = new List<int>();
        int current = end; 

        //Vòng lập truy ngược đường đi 
        while(current != -1)
        {
            temp.Add(current);
            current = parent[current];
        }
        temp.Reverse();

        //Nếu 'path' k rỗng (đã có sẵn phần tử s < v), loại bỏ phần tử đầu trùng lặp 
        if (path.Count > 0) temp.RemoveAt(0);
        path.AddRange(temp);
    }

    static (int, List<int>) FindShortesPath2()
    {
        var (distFromS, parentFromS) = DijkstraBai_2(s); // Từ s đến nơi đỉnh
        var (distFromX, parentFromX) = DijkstraBai_2(x); // Từ x đến nơi đỉnh 

        if (distFromS[x] == INF || distFromX[x] == INF)
            return (-1, new List<int>()); //K có đường đi 

        int totalDistance = distFromS[x] + distFromX[t]; //Tổng trọng số đường đi 
        List<int> path = new List<int>();

        //Truy vết đường đi từ s -> x
        GetPath(s, x, parentFromS, path);

        //Truy vết đường đi từ x -> s
        GetPath(x, t, parentFromX, path);   

        return (totalDistance, path);
    }

    /*
     * Dữ liệu ra: File văn bản NganNhatX.OUT
        • Dòng thứ nhất ghi một số nguyên là độ dài đường đi ngắn nhất tìm được
        • Dòng thứ hai ghi các đỉnh của đường đi từ đỉnh 𝑠 đến đỉnh 𝑡 đi qua đỉnh 𝑥 (bao gồm cả 2 đỉnh 𝑠, 𝑡) 
     */
    static void WriteFileBai_2(string out_file)
    {
        using(StreamWriter sw = new StreamWriter(out_file))
        {
            var (distance, v_path) = FindShortesPath2();
            if(distance == -1)
            {
                sw.WriteLine("-1");
                return;
            }
            sw.WriteLine(distance);
            sw.WriteLine(string.Join(" ", v_path));
        }
    }

    //Hàm chuẩn bị chạy bài 2
    static void Bai2()
    {
        ReadMatrixBai_2("NganNhatX.INP");
        WriteFileBai_2("NganNhatX.OUT");
    }


    /* Bài 3. Đường đi ngắn nhất giữa các cặp đỉnh 
     *  Hãy tìm đường đi ngắn nhất giữa các cặp đỉnh theo thuật toán Floyd – Warshall (tức là tìm ma trận 𝑑𝑖𝑠𝑡[𝑖, 𝑗] là độ
        dài đường đi ngắn nhất từ đi từ đỉnh 𝑖 đến đỉnh 𝑗). 
     * Dữ liệu vào: Đọc từ file FloydWarshall.INP
        • Dòng đầu tiên chứa 1 số nguyên 𝑛 (số đỉnh của đồ thị)
        • 𝑛 dòng sau, mỗi dòng chứa 𝑛 số nguyên mô tả ma trận trọng số của đồ thị 
     */
    static void ReadMatrixBai_3(string inp_file)
    {
        string[] lines = File.ReadAllLines(inp_file);
        n = int.Parse(lines[0]);// Số đỉnh 

        v_dist3 = new int[n+1,m+1];
        for(int i = 0; i < n; i++)
        {
            string[] row = lines[i].Split();
            for(int j = 0; j <= n; j++)
            {
                v_dist3[i,j] = int.Parse(row[j-1]);
                if(i != j && v_dist3[i,j] == 0) //không có cạnh thì gắn vô cực 
                {
                    v_dist3[i, j] = INF / 2;
                }
            }
        }
    }


    //Thuật toán Floyd-warshall
    static void FloydWarshall_Algorithm()
    {
        for(int k = 0;k < m;k++)
        {
            for(int i = 1;i <= n; i++)
            {
                for(int j = 1;j <= n; j++)
                {
                    //Tính lại trọng số, nếu nhỏ hơn trọng số đang lưu thi thay đổi 
                    if (v_dist3[i, j]> v_dist3[i,k] - v_dist3[k, j])
                    {
                        v_dist3[i, j] = v_dist3[i, k] + v_dist3[k, j];
                    }
                }
            }
        }
    }
    /*
     *  Dữ liệu ra: Ghi ra file FloydWarshall.OUT
        • Dòng đầu tiên chứa 1 số nguyên 𝑛 (số đỉnh của đồ thị)
        • 𝑛 dòng sau, mỗi dòng chứa 𝑛 số nguyên là ma trận 𝑑𝑖𝑠𝑡[𝑖, 𝑗]
     */
    static void WriteFileBai_3 (string out_file)
    {
        using (StreamWriter sw = new StreamWriter(out_file)) 
        { 
            sw.WriteLine(n);
            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    if (v_dist3[i, j] == INF / 2) sw.WriteLine("INF "); //Nếu vô cực 
                    else sw.WriteLine(v_dist3[i, j] + " ");
                }
                sw.WriteLine();
            }
        }
    }


    //Hàm chuẩn bị chạy bài 3
    static void Bai3()
    {
        ReadMatrixBai_3("FloydWarshall.INP");
        FloydWarshall_Algorithm();
        WriteFileBai_3("FloydWarshall.OUT");
    }

}

public static class Buoi6
{
    static int m, n, x;
    static List<(int, int)>[] v_MatrixGraph; //Danh sách kề (đỉnh, trọng số) 
    static bool[] v_visited;
    static List<(int, int, int)> v_treeEdges; //Lưu các cạnh của cây khung 
    static List<(int, int, int)> v_minTreeEdges; //Lưu các cạnh của cây khung nhỏ nhất 

    static int v_totalEdges = 0; //Tổng trọng số của cây khung  
    static int[] v_parent; //Mảng đại diện của tập hợp con trong Union-Find
    static int q; //số nguyên Q trong bài 5

    public static void Run()
    {
        //Bai1();
        //Bai2();
        //Bai3();
        //Bai4():
        //Bai5();
    }

    /* Bài 1. Tìm cây khung> Hãy tìm cây khung của đồ thị 𝐺 theo thuật toán DFS tại đỉnh 1.
     * Dữ liệu vào: File văn bản CayKhung.INP
        • Dòng đầu tiên chứa hai số nguyên 𝑛, 𝑚 (𝑛, 𝑚 ≤ 105), trong đó 𝑛 là số đỉnh, 𝑚 là số cạnh của đồ
            thị.
        • 𝑚 dòng tiếp theo, mỗi dòng chứa hai số 𝑢, 𝑣, 𝑤 mô tả cạnh (𝑢, 𝑣) có trọng số 𝑤 trong đồ thị. 
     */
    static void ReadMatrixBai_1(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        // Dòng đầu tiên chứa 4 số nguyên 𝑛, 𝑚, 𝑠, 𝑡
        string[] firstLine = lines[0].Split();
        n = int.Parse(firstLine[0]); // Đọc số đỉnh
        m = int.Parse(firstLine[1]); // Đọc số cạnh
        

        // Khởi tạo ma trận
        v_MatrixGraph = new List<(int, int)>[n + 1];
        for (int i = 1; i < n; i++)
        {
            v_MatrixGraph[i] = new List<(int, int)>();
        }

        //𝑚 dòng tiếp theo, mỗi dòng chứa 3 số 𝑢, 𝑣, 𝑤 mô tả cung (𝑢, 𝑣) có trọng số w
        for (int i = 1; i <= m; i++)
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]); //(đầu cạnh)
            int v = int.Parse(edge[1]); //(cuối cạnh)
            int w = int.Parse(edge[2]); //trọng số 

            v_MatrixGraph[u].Add((v, w)); // Đỉnh u có kề v với trọng số w
            v_MatrixGraph[v].Add((u, w)); // Đỉnh v có kề u với trọng số w
        }
    }


    static void DFS(int u)
    {
        //Dùng đệ qui 
        v_visited[u] = true;
        foreach(var (v, w) in v_MatrixGraph[u])
        {
            if (!v_visited[v])
            {
                v_treeEdges.Add((u, v, w));
                DFS(v);

            }
        }
    }

    static void DFS_Stack(int start)
    {
        //Dùng stack, tránh bị deadloop, hiệu quả cho đồ thị lớn 
        Stack<int> v_stack = new Stack<int>();  

        v_stack.Push(start);
        v_visited[start] = true; 

        while(v_stack.Count > 0) //Lập đến khi hết stack 
        {
            int u = v_stack.Pop(); //Lấy giá trị trên cùng ra
            foreach(var(v, w) in v_MatrixGraph[u])
            {
                if (!v_visited[v])
                {
                    v_visited[v] = true;
                    v_stack. Push(u); // Cho vafo stack
                    v_treeEdges.Add((u, v, w)); //Cho vao cay khung 
                }
            }
        }
    }


    /*
     * Dữ liệu ra: File văn bản CayKhung.OUT
        • Dòng đầu tiên ghi số (𝑛 − 1) là số cạnh trong cây khung.
        • 𝑛 − 1 dòng tiếp theo, mỗi dòng gồm ba số nguyên 𝑢, 𝑣, 𝑤 mô tả cạnh (𝑢, 𝑣) có trọng số 𝑤 là một
        cạnh trong cây khung. 
     */
    static void WriteFileBai_1(string out_file)
    {
        using (StreamWriter sw = new StreamWriter(out_file))
        {
            sw.WriteLine(v_treeEdges.Count);
            foreach(var (u, v,w) in v_treeEdges)
            {
                sw.WriteLine($"{u} {v} {w}");
            }
        }
        Console.WriteLine("Write To File Bai1_Buoi6");
    }

    //Hàm chuẩn bị chạy bài 1
    static void Bai1()
    {
        ReadMatrixBai_1("CayKhung.INP");
        v_visited = new bool[n + 1];
        v_treeEdges = new List<(int, int, int)>();

        //DFS(1);
        DFS_Stack(1);
        WriteFileBai_1("CayKhung.OUT");
    }


    /* Bài 2. Tìm cây khung nhỏ nhất theo thuật toán Kruskal   
     * Dữ liệu vào: File văn bản Kruskal.INP  
        • Dòng đầu tiên chứa hai số nguyên 𝑛, 𝑚 (𝑛, 𝑚 ≤ 105), trong đó 𝑛 là số đỉnh, 𝑚 là số cạnh của đồ 
        thị.  
        • 𝑚 dòng tiếp theo, mỗi dòng  chứa ba số 𝑢, 𝑣, 𝑤 cho biết cạnh (𝑢, 𝑣) có trọng số 𝑤 (1 ≤ 𝑤 ≤ 104) 
     */
    static void ReadMatrixBai_2(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        // Dòng đầu tiên chứa 4 số nguyên 𝑛, 𝑚, 𝑠, 𝑡
        string[] firstLine = lines[0].Split();
        n = int.Parse(firstLine[0]); // Đọc số đỉnh
        m = int.Parse(firstLine[1]); // Đọc số cạnh


        // Khởi tạo ma trận
        v_MatrixGraph = new List<(int, int)>[n + 1];
        for (int i = 1; i < n; i++)
        {
            v_MatrixGraph[i] = new List<(int, int)>();
        }

        //𝑚 dòng tiếp theo, mỗi dòng chứa 3 số 𝑢, 𝑣, 𝑤 mô tả cung (𝑢, 𝑣) có trọng số w
        for (int i = 1; i <= m; i++)
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]); //(đầu cạnh)
            int v = int.Parse(edge[1]); //(cuối cạnh)
            int w = int.Parse(edge[2]); //trọng số 

            //Thêm cạnh vào danh sách (sắp xếp theo trọng số))
            v_treeEdges.Add((w, u, v)); 
          
        }
    }

    private static int Find(int u)
    {
        Stack<int> stack = new Stack<int>();    
        while (v_parent[u] != u)
        {
            stack.Push(u);
            u = v_parent[u];
        }
        //Áp dụng nén đường đi
        while (stack.Count > 0)
        {
            int node = stack.Pop();
            v_parent[node] = u;
        }
        return u;
    }

    private static void Union (int u, int v)
    {
        int rootU = Find(u);
        int rootV = Find(v);
        if(rootU != rootV)
            v_parent[rootV] = rootU; //Hợp nhất hai tập hợp, 

    }

    static void Kruskal()
    {
        v_treeEdges.Sort(); //Sắp xếp cạnh theo trọng số tăng dần 
        v_parent = new int[n + 1];
        v_minTreeEdges = new List<(int, int, int)>();
        for(int i = 0; i <= n; i++)
        {
            v_parent[i] = i;
        }
        foreach(var(w, u, v) in v_treeEdges)
        {
            //Nếu u và v không thuộc cùng tập hợp, không cùng gốc 
            if(Find(u) != Find(v))
            {
                Union(u, v); //ghép 2 tập hợp cùng gốc
                v_minTreeEdges.Add((u, v, w)); //Thêm vào tập cây khung nhỏ nhất 
                v_totalEdges += w;

                //Đủ n-1 cạnh thì dừng 
                if (v_minTreeEdges.Count == n - 1)
                    break;
            }
        }
    }

    /*
     * Dữ liệu ra: File văn bản Kruskal.OUT  
        • Dòng đầu tiên ghi số hai số tương ứng là số cạnh và tổng trọng số của cây khung nhỏ nhất.  
        • 𝑛 − 1 dòng tiếp theo, mỗi dòng gồm ba số 𝑢, 𝑣, 𝑤 cho biết cạnh (𝑢, 𝑣) là cạnh trong cây khung nhỏ 
        nhất có trọng số 𝑤.  
     */
    static void WriteFileBai_2(string out_file)
    {
        using (StreamWriter sw = new StreamWriter(out_file))
        {
            sw.WriteLine($"{v_minTreeEdges.Count} {v_totalEdges}");
            foreach (var (u, v, w) in v_minTreeEdges)
            {
                sw.WriteLine($"{u} {v} {w}");
            }
        }
        Console.WriteLine("Write To File Bai2_Buoi6");
    }


    //Hàm chuẩn bị chạy bài 2
    static void Bai2()
    {
        ReadMatrixBai_2("Kruskal.INP");
        Kruskal();
        WriteFileBai_2("Kruskal.OUT");
    }

    /* Bai 3: Hãy tìm cây khung nhỏ nhất của đồ thị 𝐺 theo thuật toán Prim bắt đầu từ đỉnh 1 và tính tổng độ dài các cạnh của cây 
       khung tìm được.
     * Dữ liệu vào: File văn bản Prim.INP  
        • Dòng đầu tiên chứa hai số nguyên 𝑛, 𝑚 (𝑛, 𝑚 ≤ 105), trong đó 𝑛 là số đỉnh, 𝑚 là số cạnh của đồ 
        thị.  
        • 𝑚 dòng tiếp theo, mỗi dòng  chứa ba số 𝑢, 𝑣, 𝑤 cho biết cạnh (𝑢, 𝑣) có trọng số 𝑤 (1 ≤ 𝑤 ≤ 104) 
     */
    static void ReadMatrixBai_3(string inp_file)
    {
        ReadMatrixBai_1(inp_file);
    }

    static void Prim()
    {
        v_minTreeEdges = new List<(int, int, int)>();
        v_visited = new bool[n+1]; //Đánh dấu đỉnh đã 
        SortedSet<(int, int, int)> v_pqueue = new SortedSet<(int, int, int)>();

        v_visited[1] = true; //Bắt đầu từ đỉnh 1
        foreach(var(v,w) in v_MatrixGraph[1])
        {
            v_pqueue.Add((w, 1, v)); //(trọng số, đỉnh 1, đỉnh k))
        }

        while(v_pqueue.Count > 0 && v_minTreeEdges.Count < n -1)
        {
            var (w, u, v) = v_pqueue.Min; //Lấy cạnh có trọng số nhỏ nhất 
            v_pqueue.Remove(v_pqueue.Min); //Xóa khỏi hàng đợi 

            if (v_visited[v]) continue; //Bỏ qua nếu định đã xem 

            v_minTreeEdges.Add((u, v, w)); //Thêm cạnh vào tập cây 
            v_totalEdges += w; // tính tổng trọng số đã đi qua 
            v_visited[v] = true; // đánh dấu đỉnh đã xét 

            foreach(var(du, dw) in v_MatrixGraph[v])
                if (!v_visited[du])
                    v_pqueue.Add((dw,v,du));
        }

    }


    /*
     * Dữ liệu ra: File văn bản Prim.OUT  
        • Dòng đầu tiên ghi số hai số tương ứng là số cạnh và tổng trọng số của cây khung nhỏ nhất.  
        • 𝑛 − 1 dòng tiếp theo, mỗi dòng gồm ba số 𝑢, 𝑣, 𝑤 cho biết cạnh (𝑢, 𝑣) là cạnh trong cây khung nhỏ 
        nhất có trọng số 𝑤.   
     */
    static void WriteFileBai_3(string out_file)
    {
        using (StreamWriter sw = new StreamWriter(out_file))
        {
            sw.WriteLine($"{v_minTreeEdges.Count} {v_totalEdges}");
            foreach (var (u, v, w) in v_minTreeEdges)
            {
                sw.WriteLine($"{u} {v} {w}");
            }
        }
        Console.WriteLine("Write To File Bai3_Buoi6");
    }

    //Hàm chuẩn bị chạy bài 3
    static void Bai3()
    {
        ReadMatrixBai_3("Prim.INP");
        Prim();
        WriteFileBai_3("Prim.OUT");
    }


    /* Bài 4: Hãy tìm cây khung nhỏ nhất có độ dài cạnh nhỏ nhất trong cây khung lớn hơn hay bằng 𝑥. 
     * Input: CayKhungX.INP
        • Dòng thứ nhất chứa ba số 𝑛, 𝑚, 𝑥
        • 𝑀 dòng sau chứa bộ ba số (𝑢𝑖, 𝑣𝑖, 𝑤𝑖) mô tả cạnh thứ (𝑢𝑖, 𝑣𝑖) có trọng số 𝑤𝑖 (1 ≤ 𝑤𝑖≤ 104)
     */
    static void ReadMatrixBai_4(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        // Dòng đầu tiên chứa 4 số nguyên 𝑛, 𝑚, x
        string[] firstLine = lines[0].Split();
        n = int.Parse(firstLine[0]); // Đọc số đỉnh
        m = int.Parse(firstLine[1]); // Đọc số cạnh
        x = int.Parse(firstLine[2]); //Điều kiện x

        //𝑚 dòng tiếp theo, mỗi dòng chứa 3 số 𝑢, 𝑣, 𝑤 mô tả cung (𝑢, 𝑣) có trọng số w
        for (int i = 1; i <= m; i++)
        {
            string[] edge = lines[i].Split();
            int u = int.Parse(edge[0]); //(đầu cạnh)
            int v = int.Parse(edge[1]); //(cuối cạnh)
            int w = int.Parse(edge[2]); //trọng số 

            // if(w >= x) //Chỉ thêm cạnh có trọng số >= x
            //Thêm cạnh vào danh sách (sắp xếp theo trọng số))
                    v_treeEdges.Add((w, u, v));

        }
    }

    //Hàm xử lý thuật toán Kruskal có điều kiện: tìm cây khung nhỏ nhất với cạnh có trọng số >= x)
    static int KruskalBai_4()
    {
        int v_total = 0;
        int v_count = 0; 

        //Lọc chỉ lấy cạnh có trọng số >= x
        List<(int,int,int)> v_filteredEdges = new List<(int,int,int)> (); 
        foreach(var edge in v_treeEdges)
        {
            if(edge.Item1 >= x) //chỉ lấy cạnh có trọng số >= x
                v_filteredEdges.Add(edge);
        }
        v_filteredEdges.Sort(); //Sắp xếp cạnh theo trọng số tăng dần 
        v_parent = new int[n + 1];
        v_minTreeEdges = new List<(int, int, int)> ();
        for(int i = 0; i <= n; i++)
        {
            v_parent[i] = i; //Khởi tạo tập hợp riêng biệt cho mỗi đỉnh 
        }
        foreach(var(w, u, v) in v_filteredEdges)
        {
            if(Find(u) != Find(v)) //Nếu u và v k thuộc cùng tập hợp, k cùng gốc
            {
                Union(u, v); //Ghép 2 tập hợp cùng gốc 
                v_minTreeEdges.Add((u, v, w)); //Thêm vào tập hợp cây khung nhỏ nhất 
                v_total += w; 
                v_count++; //khác với bài 2
                if (v_count == n - 1) //Đủ n-1 cạnh thì dừng
                    return v_total; //khác với bài 2
            }
        }
        return -1;
    }

    /*
     * Output: CayKhungX.OUT
        • Chứa số −1 nếu không có cây khung thỏa điều kiện bài toán, nếu có thì ghi tổng trọng số các cạnh
        của cây khung tìm được. 
     */
    static void WriteFileBai_4(string out_file, int result)
    {
        File.WriteAllText(out_file, result.ToString());
    }

    //Hàm chuẩn bị chạy bài 4
    static void Bai4()
    {
        ReadMatrixBai_4("CayKhungX.INP");
        int result = KruskalBai_4();
        WriteFileBai_4("CayKhungX.OUT", result);
    }

    /* Bài 5: Bài tập thực tế    
     * Có 𝑛 ngôi làng được đánh số từ 1 đến 𝑛, và bạn nên xây dựng một số con đường để mỗi hai làng có thể
    thông nhau với nhau. Ta nói hai làng A và B là thông nhau khi và chỉ khi có một con đường giữa A và B,
    hoặc tồn tại một làng C sao cho có một con đường giữa A và C và, C và B thông nhau.
    Chúng ta biết rằng đã có một số con đường giữa một số làng và công việc của bạn là xây dựng một số con
    đường sao cho tất cả các làng được thông nhau và chiều dài của tất cả các con đường được xây dựng là tối thiểu. 
    làng = đỉnh 
     */

    /*
     * Dữ liệu vào: File văn bản Roads.INP
        • Dòng đầu tiên là số nguyên 𝑛 (3 ≤ 𝑛 ≤ 100) là số ngôi làng.
        • 𝑛 dòng tiếp theo, dòng thứ 𝑖 chứa chứa 𝑛 số nguyên, số nguyên thứ 𝑗 trong 𝑛 số nguyên này là
            khoảng cách (giá trị khoảng cách là một số nguyên thuộc [1,1000]) giữa làng 𝑖 và làng 𝑗.
        • Sau đó là một số nguyên 𝑄
        • 𝑄 dòng tiếp theo, mỗi dòng chứa hai số nguyên 𝑎 và 𝑏 (1 ≤ 𝑎 < 𝑏 ≤ 𝑛) cho viết con đường giữa
            làng 𝑎 và làng 𝑏 đã được xây dựng. 
     */
    static void ReadMatrixBai_5(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);
        n = int.Parse(lines[0]);

        v_treeEdges = new List<(int, int, int)>();

        //Đọc ma trận kề 
        for(int i = 1; i <= n; i++)
        {
            string[] row = lines[i].Split();
            //chỉ đọc nửa trên của ma trận( đồ thị vô hướng) 
            for(int j = i+1; j <= n; j++)
            {
                // Đọc trọng số từ ma trận
                int w = int.Parse(row[j - 1]);
                // Thêm cạnh vào danh sách 
                v_treeEdges.Add((w, i - 1, j - 1));
            }
        }
        //Đọc số cạnh đã xây n + 1
        q = int.Parse(lines[n + 1]);

        //Thêm các cạnh đã xây vào danh sách với trọng số 0, 0 là để ưu tiên cạnh trong Kruskal
        for(int i = 1; i <= q; i++)
        {
            string[] edgeData = lines[n + 1 + i].Split();
            int a = int.Parse(edgeData[0]) - 1; //Chuyển đổi chỉ số về based
            int b = int.Parse(edgeData[1]) - 1;
            v_treeEdges.Add((0, a, b)); //Thêm cạnh đã xây với trọng số 0
        }            
    }
    static int KruskalBai_5()
    {
        v_treeEdges.Sort(); //Sắp xếp cạnh theo trọng số tăng dần 
        v_parent = new int[n];      
        for (int i = 0; i <= n; i++)
        {
            v_parent[i] = i;
        }
        int v_total = 0, v_count = 0;
        foreach (var (w, u, v) in v_treeEdges)
        {
            //Nếu cùng làng gốc 
            if (Find(u) != Find(v))
            {
                Union(u, v); // cho 2 làng cùng cha
                v_total += w; //Tăng trọng số tổng 
                v_count++; //Đếm số đường đi 

                //Đã xây xong đường đi
                if (v_count == n - 1)
                    break;
            }
        }
        //Nếu tìm thấy đường đi thì trả về tổng trọng số 
        return (v_count == n - 1) ? v_total : -1;
    }

    /*
     * Output: File văn bản Roads.OUT
        • Chứa một dòng duy nhất chứa một số nguyên là chiều dài của tất các con đường cần được xây sao
        cho tất cả các làng đều thông nhau và giá trị này là giá trị nhỏ nhất. 
     */
    static void WriteFileBai_5(string out_file, int result)
    {
        WriteFileBai_4(out_file, result);
    }

    //Hàm chuẩn bị chạy bài 5
    static void Bai5()
    {
        ReadMatrixBai_5("Roads.INP");
        int result = KruskalBai_5();
        WriteFileBai_5("Roads.OUT", result);
    }
}

public static class Buoi7
{
    static int n; //Sổ đỉnh đồ thị 
    static int[,] v_arrayMatrix; //Ma trận kề đồ thị 

    static List<(int, int)>[] v_MatrixGraph; //Danh sách kề (đỉnh, trọng số) 
    static bool[] v_visited;
    public static void Run()
    {
        //Bai1();
        //Bai2();
        //Bai3();
        
    }

    /* Bài 1. Kiểm tra Euler trên đồ thị vô hướng
     * Dữ liệu vào: File văn bản EulerVoHuong.INP
        • Dòng đầu tiên chứa số nguyên 𝑛 là số đỉnh của đồ thị.
        • 𝑛 dòng tiếp theo, mỗi dòng chứa 𝑛 số biểu diễn ma trận kề của đồ thị. 
     */
    static void ReadMatrixBai_1(string inp_file)
    {
        //đọc dữ liệu từ file đầu vào
        string[] lines = File.ReadAllLines(inp_file);

        //số đỉnh của đồ thị
        n = int.Parse(lines[0]);

        //ma trận kề
        v_arrayMatrix = new int[n+1, n+1];

        for (int i = 0; i < n; i++)
        {
            string[] row = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < n; j++)
            {
                v_arrayMatrix[i, j] = int.Parse(row[j - 1]);
            }
        }
    }

    //Kiểm tra đồ thị có chu trình Euler hoặc đường đi euler 
    private static bool Connected()
    {
        v_visited = new bool[n + 1];
        int startNode = -1; 

        //Tìm một đỉnh có ít nhất một cạnh để bắt đầu DFS, có thể bắt đầu tử đỉnh 1
        for(int i = 1; i <= n; i++)
        {
            for(int j = 1; j <= n; j++)
            {
                if (v_arrayMatrix[i,j] > 0)
                {
                    startNode = i;
                    break;
                }
            }
            if (startNode != -1) break;
        }
        if (startNode == -1) return false; //Nếu k có cạnh nào, đồ thị không liên thông 
        DFSBai_1(startNode); //Kiểm tra liên thông 

        //Kiểm tra tất cả các đỉnh có bậc > 0 có được duyệt hay không
        for(int i = 1; i <= n; i++)
        {
            if (!v_visited[i])
            {
                for(int j = 1; j <= n; j++)
                {
                    if(v_arrayMatrix[i,j] > 0) return false; 
                }
            }
        }
        return true;
    }

    //Hàm DFS kiểm tra tính liên thông
    private static void DFSBai_1(int u)
    {
        v_visited[u] = true; //Đánh dấu đỉnh u đã được thăm 
        //Lần lượt duyệt từng đỉnh để gọi đệ qui
        for(int v = 1; v<= n; v++)
        {
            if (v_arrayMatrix[u, v] > 0 && !v_visited[v])
            {
                DFSBai_1(v);
            }
        }
    }

    private static int CountOddDegree()
    {
        int v_oddCount = 0;
        //duyệt hàng
        for(int i = 1; i <= n; i++)
        {
            int v_degree = 0;
            //Duyệt cột
            for(int j = 1; j <= n; j++)
            {
                //Đếm số cạnh của đỉnh i
                v_degree += v_arrayMatrix[i, j];
            }
            if (v_degree % 2 == 1) v_oddCount++; //Nếu là bậc lẻ thì tăng count
        }
        return v_oddCount;
    }

    static int EulerBai_1()
    {
        if(!Connected()) return 0;
        int v_sum = CountOddDegree();
        if (v_sum == 0) return 1; //Chu trình euler, không có đỉnh lẻ
        if(v_sum == 1) return 2; //Đường đi euler, có 2 đỉnh lẻ 
        return 0;
    }

    /* Dữ liệu ra: File văn bản EulerVoHuong.OUT • Dòng duy nhất chứa số nguyên 𝑘, trong đó
             o 𝑘 = 0: 𝐺 là đồ thị không có chu trình Euler, cũng không có đường đi Euler 
             o 𝑘 = 1: 𝐺 là đồ thị có chu trình Euler
             o 𝑘 = 2: 𝐺 là đồ thị có đường đi Euler 
     */
    static void WriteFileBai_1(string out_file, int result)
    {
        File.WriteAllText(out_file, result.ToString());
    }


    //Hàm chuẩn bị chạy bài 1
    static void Bai1()
    {
        ReadMatrixBai_1("EulerVoHuong.INP");
        int result = EulerBai_1();
        WriteFileBai_1("EulerVoHuong.OUT", result);
    }

    /* Bài 2. Kiểm tra Euler trên đồ thị có hướng
     * Dữ liệu vào: File văn bản EulerCoHuong.INP
        • Dòng đầu tiên chứa số nguyên 𝑛 là số đỉnh của đồ thị.
        • 𝑛 dòng tiếp theo, mỗi dòng chứa 𝑛 số biểu diễn ma trận kề của đồ thị
     */
    static void ReadMatrixBai_2(string inp_file)
    {
       ReadMatrixBai_1(inp_file);
    }

    static void DFSBai_2(int u)
    {
        v_visited[u] = true;
        for(int v = 1; v <= n; v++)
        {
            if ((v_arrayMatrix[u,v] > 0 || v_arrayMatrix[v, u]> 0) && !v_visited[v])
            {
                DFSBai_2(v);
            }
        } 
    }
    //Hàm kiểm đồ thị có liên thông yêu không
    //Liên thông yếu là cặp đỉnh không có cặp cạnh có hướng k nối tới nhau 
    static bool IsWeakly()
    {
        v_visited = new bool[n + 1];
       
    }


    static int EulerBai_2()
    {

    }
    /*
     * Dữ liệu ra: File văn bản EulerCoHuong.OUT chứa một dòng duy nhất chứa số nguyên 𝑘, trong đó
        • 𝑘 = 0: 𝐺 là đồ thị không có chu trình Euler, cũng không có đường đi Euler
        • 𝑘 = 1: 𝐺 là đồ thị có chu trình Euler
        • 𝑘 = 2: 𝐺 là đồ thị có đường đi Euler 
     */
    static void WriteFileBai_2(string out_file, int result)
    {
        File.WriteAllText(out_file, result.ToString());
    }

    //Hàm chuẩn bị chạy bài 2
    static void Bai2()
    {
        ReadMatrixBai_2("EulerCoHuong.INP");
        int result = EulerBai_2();
        WriteFileBai_2("EulerCoHuong.OUT", result);
    }
}

