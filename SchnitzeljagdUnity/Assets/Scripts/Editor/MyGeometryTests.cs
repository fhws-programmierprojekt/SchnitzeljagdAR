using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class MyGeometryTests {

    [Test]
    public void TestIsWithinAngleInterval() {
        
        // Arrange
        // Vectors are identical
        Vector3 v = new Vector3(1, 0, 1);

        // Act
        // Angle Interval of absolute smallest numbers
        bool isIntervalSmall = MyGeometry.IsWithinAngle(v, v, 0, 0);
        // Angle Interval of absolute greatest numbers
        bool isIntervalGreat = MyGeometry.IsWithinAngle(v, v, -180, 180);
        // Angle Interval with Start too great
        bool isNotIntervalStartTooGreat = MyGeometry.IsWithinAngle(v, v, 181, 0);
        // Angle Interval with End too great
        bool isNotIntervalEndTooGreat = MyGeometry.IsWithinAngle(v, v, 0, 181);
        // Angle Interval with Start too great
        bool isNotIntervalStartTooSmall = MyGeometry.IsWithinAngle(v, v, -181, 0);
        // Angle Interval with End too great
        bool isNotIntervalEndTooSmall = MyGeometry.IsWithinAngle(v, v, 0, -181);

        // Assert
        Assert.True(isIntervalSmall);
        Assert.True(isIntervalGreat);

        Assert.False(isNotIntervalStartTooGreat);
        Assert.False(isNotIntervalEndTooGreat);

        Assert.False(isNotIntervalStartTooSmall);
        Assert.False(isNotIntervalEndTooSmall);
    }
    [Test]
    public void TestIsWithinAngleTop() {

        // Arrange
        // Vectors are identical
        // Vector A is pointing upward
        Vector3 vA = new Vector3(1, 0, 1);
        // Vector B is pointing upward
        Vector3 vB = new Vector3(1, 0, 1);

        // Act
        // Angle of Vectors is identical to Reference Angle
        bool isAngle = MyGeometry.IsWithinAngle(vA, vB, 0, 0);
        // Angle of Vectors is within Reference Angle
        bool isWithinAngle = MyGeometry.IsWithinAngle(vA, vB, -1, 1);
        // Angle of Vectors is not withing Reference Angle
        bool isNotWithinAngle = MyGeometry.IsWithinAngle(vA, vB, 1, -1);


        // Assert
        Assert.True(isAngle);

        Assert.True(isWithinAngle);
        Assert.False(isNotWithinAngle);
    }
    [Test]
    public void TestIsWithinAngleBottom() {

        // Arrange
        // Vectors are not identical
        // Vector A is pointing upward
        Vector3 vA = new Vector3(1, 0, 1);
        // Vector B is pointing downward
        Vector3 vB = new Vector3(-1, 0, -1);

        // Act
        // Angle of Vectors is identical to Reference Angle
        bool isAngleOuter = MyGeometry.IsWithinAngle(vA, vB, -180, 180);
        bool isAngleInner = MyGeometry.IsWithinAngle(vA, vB, 180, -180);
        // Angle of Vectors is within Reference Angle
        bool isWithinAngle = MyGeometry.IsWithinAngle(vA, vB, 179, -179);
        // Angle of Vectors is not withing Reference Angle
        bool isNotWithinAngle = MyGeometry.IsWithinAngle(vA, vB, -179, 179);

        // Assert
        Assert.True(isAngleOuter);
        Assert.True(isAngleInner);

        Assert.True(isWithinAngle);
        Assert.False(isNotWithinAngle);
    }
    [Test]
    public void TestIsWithinAngleLeft() {

        // Arrange
        // Vectors are not identical
        // Vector A is pointing upward
        Vector3 vA = new Vector3(1, 0, 1);
        // Vector B is pointing leftward
        Vector3 vB = new Vector3(1, 0, -1);

        // Act
        // Angle of Vectors is identical to Reference Angle
        bool isAngle = MyGeometry.IsWithinAngle(vA, vB, 90, 90);
        // Angle of Vectors is within Reference Angle
        bool isWithinAngle = MyGeometry.IsWithinAngle(vA, vB, 89, 91);
        // Angle of Vectors is not withing Reference Angle
        bool isNotWithinAngle = MyGeometry.IsWithinAngle(vA, vB, 91, 89);

        // Assert
        Assert.True(isAngle);

        Assert.True(isWithinAngle);
        Assert.False(isNotWithinAngle);
    }
    [Test]
    public void TestIsWithinAngleRight() {

        // Arrange
        // Vectors are not identical
        // Vector A is pointing upward
        Vector3 vA = new Vector3(1, 0, 1);
        // Vector B is pointing rightward
        Vector3 vB = new Vector3(-1, 0, 1);

        // Act
        // Angle of Vectors is identical to Reference Angle
        bool isAngle = MyGeometry.IsWithinAngle(vA, vB, -90, -90);
        // Angle of Vectors is within Reference Angle
        bool isWithinAngle = MyGeometry.IsWithinAngle(vA, vB, -91, -89);
        // Angle of Vectors is not withing Reference Angle
        bool isNotWithinAngle = MyGeometry.IsWithinAngle(vA, vB, -89, -91);

        // Assert
        Assert.True(isAngle);

        Assert.True(isWithinAngle);
        Assert.False(isNotWithinAngle);
    }


}
