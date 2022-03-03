﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Security.Cryptography;


// member data here are named so they can be serialized
// automatically, so don't rename anything

/// <summary>
/// 本地加密
/// </summary>
public static class LocalCryptoGraphy
{
    static public string ENCRYPTION_HEADER = "ProPlay_Local_";

    //DO NOT CHANGE THIS
    // or encrypted bundles will not be readable anymore
    static public byte[] ENCRYPTION_IV =
    {
        0x11, 0xe5, 0xf2, 0xff, 0x87, 0x5a, 0x47, 0x72,
        0x54, 0x8c, 0xcd, 0x10, 0xa7, 0x8e, 0xe0, 0x76
        };


    static public readonly int KEY_LENGTH = 32;

    static public byte[] GetLocalKey()
    {
        //var sysInfo = SystemInfo.deviceUniqueIdentifier;
        var sysInfo = LocalInfoHelper.GetCpuID();
        var sysInfoBytes = Encoding.Unicode.GetBytes(sysInfo);
        byte[] result = null;
        using (var sha = SHA256Managed.Create())
        {
            result = sha.ComputeHash(sysInfoBytes);
        }
        return result;
    }

    static public byte[] CONSTANT_KEY =
    {
        0x96, 0x93, 0xc9, 0xea, 0x60, 0x66, 0x25, 0xc8,
        0x33, 0x66, 0x2e, 0xa7, 0xbe, 0x3f, 0x0d, 0xf5,
        0xbf, 0x27, 0x58, 0x7f, 0x44, 0xad, 0xe7, 0x80,
        0x97, 0xa1, 0xc6, 0xbf, 0xe9, 0x07, 0xe4, 0xbf
    };

    static public byte[] Encrypt(string plainText, bool useConstantKey = false)
    {
        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
        {
            throw new ArgumentNullException("Invalid plainText");
        }

        Debug.Info("LocalCryptoGraphy: encrypting " + plainText.Length + " bytes of data");
        var key = useConstantKey ? CONSTANT_KEY : GetLocalKey();
        Debug.Info((KEY_LENGTH == key.Length).ToString());
        var IV = ENCRYPTION_IV;
        byte[] encrypted;
        // Create an AesCryptoServiceProvider object
        // with the specified key and IV.
        using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
        {
            // Create a decrytor to perform the stream transform.
            var encryptor = aes.CreateEncryptor(key, IV);
            // Create the streams used for encryption.
            using (var outStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(outStream, encryptor, CryptoStreamMode.Write))
            {
                using (var input = new StreamWriter(cryptoStream))
                {
                    input.Write(ENCRYPTION_HEADER);
                    //Write all data to the stream.
                    input.Write(plainText);
                }
                encrypted = outStream.ToArray();
            }
        }
        // var testDecrypt = Decrypt(encrypted);
        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }

    static public string Decrypt(byte[] cipherText, bool useConstantKey = false)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
        {
            throw new ArgumentNullException("Invalid cipherText");
        }

        Debug.Info("LocalCryptoGraphy: decrypting " + cipherText.Length + " bytes of data");
        var key = useConstantKey ? CONSTANT_KEY : GetLocalKey();
        Debug.Info((KEY_LENGTH == key.Length).ToString());
        var IV = ENCRYPTION_IV;
        // Declare the string used to hold
        // the decrypted text.
        string plaintext = null;
        // Create an AesCryptoServiceProvider object
        // with the specified key and IV.
        using (var aes = new AesCryptoServiceProvider())
        {
            // Create a decrytor to perform the stream transform.
            var decryptor = aes.CreateDecryptor(key, IV);
            // Create the streams used for decryption.
            using (var inStream = new MemoryStream(cipherText))
            using (var cryptoStream = new CryptoStream(inStream, decryptor, CryptoStreamMode.Read))
            using (var output = new StreamReader(cryptoStream))
            {
                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                plaintext = output.ReadToEnd();
            }
        }

        if (!plaintext.StartsWith(ENCRYPTION_HEADER))
        {
            throw new ArgumentException("Invalid encrypted content: missing local crypto header");
        }

        return plaintext.Substring(ENCRYPTION_HEADER.Length);
    }

}
