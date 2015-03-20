cd %1
cppcheck --enable=all  --xml-version=2 "%2" 2> %3
exit