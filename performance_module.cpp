#include <iostream>
#include <string>
#include <algorithm>

extern "C" void processString(const char* str) {
    std::string s(str);
    std::transform(s.begin(), s.end(), s.begin(), ::toupper);
    std::cout << "Processed (C++): " << s << std::endl;
}
