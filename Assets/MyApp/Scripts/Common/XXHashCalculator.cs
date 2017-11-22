using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class XXHashCalculator
{ 
    private static int get_xxhash(int data, uint seed)
    {
        const uint PRIME32_2 = 2246822519U;
        const uint PRIME32_3 = 3266489917U;
        const uint PRIME32_4 = 668265263U;
        const uint PRIME32_5 = 374761393U;
        uint h32 = (uint)data * PRIME32_3;
        h32 += seed + PRIME32_5 + 4U;
        h32 = (h32 << 17) | (h32 >> 15);
        h32 *= PRIME32_4;
        h32 ^= h32 >> 15;
        h32 *= PRIME32_2;
        h32 ^= h32 >> 13;
        h32 *= PRIME32_3;
        h32 ^= h32 >> 16;
        return (int)h32;
    }

    public static int GetXXHash(int data)
    {
        return get_xxhash(data, 12345U);
    }
}
