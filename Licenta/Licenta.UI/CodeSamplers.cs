namespace Licenta.UI
{
    public static class CodeSamplers
    {
        public static readonly string CppStartCode = """
            #include <iostream>

            int main() {
                int number;
                std::cin >> number;

                // Calculate the factorial
                int factorial = 1;
                for (int i = 1; i <= number; ++i) {
                    factorial *= i;
                }

                // Display the factorial
                std::cout << factorial << std::endl;

                return 0;
            }
            
            """;
    }
}
