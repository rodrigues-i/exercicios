# CMakeList.txt : CMake project for FixServer, include source and define
# project specific logic here.
#
cmake_minimum_required (VERSION 3.8)

project ("FixServer")

set(CMAKE_CXX_STANDARD 14)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

# Add quickfix library and header files
include_directories(${CMAKE_SOURCE_DIR}/include)
link_directories(${CMAKE_SOURCE_DIR}/x64lib/Debug)

# Parse all my source files and put them in the SRC_FILES variable
file(GLOB_RECURSE SRC_FILES src/*.cpp)

# Add source files to this project's executable.
add_executable (FixServer "main.cpp" ${SRC_FILES})

# Add my header files
target_include_directories(FixServer PUBLIC ${CMAKE_SOURCE_DIR}/include)

# Link quickfix library into my project
target_link_libraries(FixServer quickfix)

if(WIN32)
  target_link_libraries(FixServer ws2_32)
endif()
