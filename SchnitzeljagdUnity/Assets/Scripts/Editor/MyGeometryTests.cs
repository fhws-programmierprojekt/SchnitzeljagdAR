using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class MyGeometryTests {

    [Test]
    public void TestIsWithinAngle() {

        // Arrange
        Vector3 from = new Vector3(1, 0, 1);
        Vector3 to = new Vector3(1, 0, 1);

        // Act
        bool isWithinAngle = MyGeometry.IsWithinAngle(from, to, -45, 45);
        bool isNotWithinAngle = MyGeometry.IsWithinAngle(from, to, 45, -45);

        // Assert
        Assert.True(isWithinAngle);
        Assert.False(isNotWithinAngle);
    }

}
