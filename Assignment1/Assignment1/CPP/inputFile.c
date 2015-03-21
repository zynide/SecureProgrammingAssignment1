bool test(const char* a, const char* b)
{
strcmp(a, b); // <- bug: The call of strcmp does not have side-effects, but the return value is ignored.
return true;
}
