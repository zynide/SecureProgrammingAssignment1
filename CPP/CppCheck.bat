cd C:\Program Files (x86)\Cppcheck
cppcheck --enable=all  --xml-version=2 "%1" 2> %2
exit