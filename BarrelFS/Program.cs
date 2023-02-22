// See https://aka.ms/new-console-template for more information

public class Program {
    public static async Task Main(String[] args) {
        var ff = "aaaaa";

        var fff = await P() + ff;
    }

    public static async Task<string> P() {
        var s = "asd";

        return s;
    }
}