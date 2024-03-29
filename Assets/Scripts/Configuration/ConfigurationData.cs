﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 10;
    float ballLifeSeconds = 10;
    float easyBallImpulseForce = 200;
    float easyMinSpawnSeconds = 5;
    float easyMaxSpawnSeconds = 10;
    float mediumBallImpulseForce = 300;
    float mediumMinSpawnSeconds = 3;
    float mediumMaxSpawnSeconds = 7;
    float hardBallImpulseForce = 400;
    float hardMinSpawnSeconds = 2;
    float hardMaxSpawnSeconds = 5;
    int ballsPerGame = 5;
    int standardBlockPoints = 1;
    int bonusBlockPoints = 2;
    int effectBlockPoints = 5;
    float standardBlockProbability = 0.7f;
    float bonusBlockProbability = 0.2f;
    float freezerBlockProbability = 0.05f;
    float speedupBlockProbability = 0.05f;
    float freezerSeconds = 2;
    float speedupFactor = 2;
    float speedupSeconds = 2;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the number of seconds the ball lives
    /// </summary>
    /// <value>ball life seconds</value>
    public float BallLifeSeconds
    {
        get { return ballLifeSeconds; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving in an easy game
    /// </summary>
    public float EasyBallImpulseForce
    {
        get { return easyBallImpulseForce; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving in a medium game
    /// </summary>
    public float MediumBallImpulseForce
    {
        get { return mediumBallImpulseForce; }
    }

    /// <summary>
    /// Gets the impulse force to apply to a ball
    /// to get it moving in a hard game
    /// </summary>
    public float HardBallImpulseForce
    {
        get { return hardBallImpulseForce; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// in an easy game
    /// </summary>
    public float EasyMinSpawnSeconds
    {
        get { return easyMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// in a medium game
    /// </summary>
    public float MediumMinSpawnSeconds
    {
        get { return mediumMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// in a hard game
    /// </summary>
    public float HardMinSpawnSeconds
    {
        get { return hardMinSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// in an easy game
    /// </summary>
    public float EasyMaxSpawnSeconds
    {
        get { return easyMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// in a medium game
    /// </summary>
    public float MediumMaxSpawnSeconds
    {
        get { return mediumMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// in a hard game
    /// </summary>
    public float HardMaxSpawnSeconds
    {
        get { return hardMaxSpawnSeconds; }
    }

    /// <summary>
    /// Gets the number of balls per game
    /// </summary>
    public int BallsPerGame
    {
        get { return ballsPerGame; }
    }

    /// <summary>
    /// Gets how many points a standard block is worth
    /// </summary>
    public int StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    /// <summary>
    /// Gets how many points a bonus block is worth
    /// </summary>
    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    /// <summary>
    /// Gets how many points an effect block is worth
    /// </summary>
    public int EffectBlockPoints
    {
        get { return effectBlockPoints; }
    }

    /// <summary>
    /// Gets the probability that a standard block
    /// will be added to the level
    /// </summary>
    /// <value>standard block probability</value>
    public float StandardBlockProbability
    {
        get { return standardBlockProbability; }
    }

    /// <summary>
    /// Gets the probability that a bonus block
    /// will be added to the level
    /// </summary>
    /// <value>bonus block probability</value>
    public float BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }

    /// <summary>
    /// Gets the probability that a freezer block
    /// will be added to the level
    /// </summary>
    /// <value>freezer block probability</value>
    public float FreezerBlockProbability
    {
        get { return freezerBlockProbability; }
    }

    /// <summary>
    /// Gets the probability that a speedup block
    /// will be added to the level
    /// </summary>
    /// <value>speedup block probability</value>
    public float SpeedupBlockProbability
    {
        get { return speedupBlockProbability; }
    }

    /// <summary>
    /// Gets the duration of the freezer effect
    /// in seconds
    /// </summary>
    /// <value>freezer seconds</value>
    public float FreezerSeconds
    {
        get { return freezerSeconds; }
    }

    /// <summary>
    /// Gets the speedup factor
    /// </summary>
    /// <value>speedup factor</value>
    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    /// <summary>
    /// Gets the duration of the speedup effect
    /// in seconds
    /// </summary>
    /// <value>speedup seconds</value>
    public float SpeedupSeconds
    {
        get { return speedupSeconds; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    void SetConfigurationDataFields(string csvValues)
    {

        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballLifeSeconds = float.Parse(values[1]);
        easyBallImpulseForce = float.Parse(values[2]);
        easyMinSpawnSeconds = float.Parse(values[3]);
        easyMaxSpawnSeconds = float.Parse(values[4]);
        mediumBallImpulseForce = float.Parse(values[5]);
        mediumMinSpawnSeconds = float.Parse(values[6]);
        mediumMaxSpawnSeconds = float.Parse(values[7]);
        hardBallImpulseForce = float.Parse(values[8]);
        hardMinSpawnSeconds = float.Parse(values[9]);
        hardMaxSpawnSeconds = float.Parse(values[10]);
        ballsPerGame = int.Parse(values[11]);
        standardBlockPoints = int.Parse(values[12]);
        bonusBlockPoints = int.Parse(values[13]);
        effectBlockPoints = int.Parse(values[14]);
        standardBlockProbability = float.Parse(values[15]) / 100;
        bonusBlockProbability = float.Parse(values[16]) / 100;
        freezerBlockProbability = float.Parse(values[17]) / 100;
        speedupBlockProbability = float.Parse(values[18]) / 100;
        freezerSeconds = float.Parse(values[19]);
        speedupFactor = float.Parse(values[20]);
        speedupSeconds = float.Parse(values[21]);
    }

    #endregion
}
