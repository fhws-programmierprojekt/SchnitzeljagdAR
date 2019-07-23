using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class MyArrayTests{

    [Test]
    public void TestRemoveAt() {

        // Arrange
        int[] testarray = new int[4] { 0, 1, 2, 3};
        int[] referencearray = new int[3] { 0, 1, 2 };
        // Act
        testarray = MyArray.RemoveAt(testarray, 3);

        // Assert
        Assert.That(testarray, Is.EqualTo(referencearray));
    }
}
