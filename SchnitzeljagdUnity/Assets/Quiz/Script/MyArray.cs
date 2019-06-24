using UnityEngine;

public static class MyArray {

    // Methods
    public static T RandomElement<T>(this T[] array) {
        return array[Random.Range(0, array.Length)];
    }

    public static T[] RemoveAt<T>(this T[] source, int index) {
        T[] sink = new T[source.Length - 1];

        int j = 0;
        for(int i = 0; i < source.Length; i++) {
            if(i != index) {
                sink[j] = source[i];
                j++;
            }
        }

        return sink;
    }

    public static T[] Shuffle<T>(this T[] array) {
        System.Random random = new System.Random();
        for(int i = array.Length; i > 0; i--) {
            int j = random.Next(i);
            T element = array[j];
            array[j] = array[i - 1];
            array[i - 1] = element;
        }
        return array;
    }
}
