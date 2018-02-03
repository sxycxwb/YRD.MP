using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;


public class RsaHelper
{


    public static string public_key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDLWcpGWaVijuXvrDdCL/1OkiCor4C3FoOY/QLKrg6018zAzRc6yv/qXSe7jg4cqm7N0v+LixH94Brqk18+wig0FAKmDOs3EByR2Y1jGGiSempaxC73UuBB+Z1mvdZ04KxYhegDH9w0xWxPJ7BjW2rbjW1tVCRuQrvRMQMBB3hCDwIDAQAB";
    public static string private_key = @"MIICXAIBAAKBgQDLWcpGWaVijuXvrDdCL/1OkiCor4C3FoOY/QLKrg6018zAzRc6yv/qXSe7jg4cqm7N0v+LixH94Brqk18+wig0FAKmDOs3EByR2Y1jGGiSempaxC73UuBB+Z1mvdZ04KxYhegDH9w0xWxPJ7BjW2rbjW1tVCRuQrvRMQMBB3hCDwIDAQABAoGAVmRwVlERvXyeXaPZ2inPQUk9zMy7L43GHQIo5HjsUJJ6L9MyMk06SpSHI9ynTDBwYMtqvBs6apSCevRfe6c7MpoVbHhdyrztsF/8NsO2nDnj+kO8Mt1iPj6EuOXQNsTM4PdmBMZx/vPOngQvluZn5PUpAYaT4UAx+L6AsUcYW2ECQQD8BxwHrI0xaQTc3dtToT3+ThTrkb5KuZPIvW3+37vchWSMytG1N3EPdZ9UcYB45zae2R3Y2SquFhGyjkMRho1/AkEAzo5G4ClLdtsTIJf3pZ2GCb+cMYnKGugdqokgajfEkHPy/JupGuvE73qG8H8nh8RsvDZylvcns9eQW+r049yzcQJAaMHnw8TUd4pIjCnnpa5rH06DYZuV9meG5zTeCMgkxTfpIKCZZHLkGuHwVWBMX3Tz/jkPL/isxenEd2ysshc0rwJBAMgRyZbgiMb0Rd+hMu+I18bjgK//DfLn96wyLGKV5+AfXzHMuIxp6BQqM0AJecmoucXIW0/cz+kDmEFgIJoBMRECQGj2IAxlkioHdsfaluC4ZZ2O6e+IQIj3N3XdEKkKI94QE9inC8RUWydJ3yqS3YXAfiTCwnTT+6Akn3PnZaiHpSc=";
    public static string input_charset = "utf-8";         //编码格式


    public static string sign(string content,string privateKey)
    {
        RSACryptoServiceProvider rsaCsp = CreateRsaProviderFromPrivateKey(privateKey);
        byte[] dataBytes = null;
        if (string.IsNullOrEmpty(input_charset))
        {
            dataBytes = Encoding.UTF8.GetBytes(content);
        }
        else
        {
            dataBytes = Encoding.GetEncoding(input_charset).GetBytes(content);
        }

        byte[] signatureBytes = rsaCsp.SignData(dataBytes, "SHA1");

        return Convert.ToBase64String(signatureBytes);
    }


    public static bool verify(string content, string signedString, string publicKey)
    {
        bool result = false;

        Encoding code = Encoding.GetEncoding(input_charset);
        byte[] Data = code.GetBytes(content);
        byte[] data = Convert.FromBase64String(signedString);
        RSACryptoServiceProvider rsaPub = CreateRsaProviderFromPublicKey(publicKey);
        SHA1 sh = new SHA1CryptoServiceProvider();
        result = rsaPub.VerifyData(Data, sh, data);
        return result;
    }

    public static string Decrypt(string cipherText,string privateKey)
    {
        return Encoding.UTF8.GetString(CreateRsaProviderFromPrivateKey(privateKey).Decrypt(System.Convert.FromBase64String(cipherText), false));
    }

    public static string Encrypt(string text,string publicKey)
    {
        return Convert.ToBase64String(CreateRsaProviderFromPublicKey(publicKey).Encrypt(Encoding.UTF8.GetBytes(text), false));
    }

    private static RSACryptoServiceProvider CreateRsaProviderFromPrivateKey(string privateKey)
    {
        var privateKeyBits = System.Convert.FromBase64String(privateKey);

        var RSA = new RSACryptoServiceProvider();
        var RSAparams = new RSAParameters();

        using (BinaryReader binr = new BinaryReader(new MemoryStream(privateKeyBits)))
        {
            byte bt = 0;
            ushort twobytes = 0;
            twobytes = binr.ReadUInt16();
            if (twobytes == 0x8130)
                binr.ReadByte();
            else if (twobytes == 0x8230)
                binr.ReadInt16();
            else
                throw new Exception("Unexpected value read binr.ReadUInt16()");

            twobytes = binr.ReadUInt16();
            if (twobytes != 0x0102)
                throw new Exception("Unexpected version");

            bt = binr.ReadByte();
            if (bt != 0x00)
                throw new Exception("Unexpected value read binr.ReadByte()");

            RSAparams.Modulus = binr.ReadBytes(GetIntegerSize(binr));
            RSAparams.Exponent = binr.ReadBytes(GetIntegerSize(binr));
            RSAparams.D = binr.ReadBytes(GetIntegerSize(binr));
            RSAparams.P = binr.ReadBytes(GetIntegerSize(binr));
            RSAparams.Q = binr.ReadBytes(GetIntegerSize(binr));
            RSAparams.DP = binr.ReadBytes(GetIntegerSize(binr));
            RSAparams.DQ = binr.ReadBytes(GetIntegerSize(binr));
            RSAparams.InverseQ = binr.ReadBytes(GetIntegerSize(binr));
        }

        RSA.ImportParameters(RSAparams);
        return RSA;
    }

    private static int GetIntegerSize(BinaryReader binr)
    {
        byte bt = 0;
        byte lowbyte = 0x00;
        byte highbyte = 0x00;
        int count = 0;
        bt = binr.ReadByte();
        if (bt != 0x02)
            return 0;
        bt = binr.ReadByte();

        if (bt == 0x81)
            count = binr.ReadByte();
        else
            if (bt == 0x82)
        {
            highbyte = binr.ReadByte();
            lowbyte = binr.ReadByte();
            byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
            count = BitConverter.ToInt32(modint, 0);
        }
        else
        {
            count = bt;
        }

        while (binr.ReadByte() == 0x00)
        {
            count -= 1;
        }
        binr.BaseStream.Seek(-1, SeekOrigin.Current);
        return count;
    }

    private static RSACryptoServiceProvider CreateRsaProviderFromPublicKey(string publicKeyString)
    {
        // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
        byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
        byte[] x509key;
        byte[] seq = new byte[15];
        int x509size;

        x509key = Convert.FromBase64String(publicKeyString);
        x509size = x509key.Length;

        // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
        using (MemoryStream mem = new MemoryStream(x509key))
        {
            using (BinaryReader binr = new BinaryReader(mem))  //wrap Memory Stream with BinaryReader for easy reading
            {
                byte bt = 0;
                ushort twobytes = 0;

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();    //advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();   //advance 2 bytes
                else
                    return null;

                seq = binr.ReadBytes(15);       //read the Sequence OID
                if (!CompareBytearrays(seq, SeqOID))    //make sure Sequence for OID is correct
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
                    binr.ReadByte();    //advance 1 byte
                else if (twobytes == 0x8203)
                    binr.ReadInt16();   //advance 2 bytes
                else
                    return null;

                bt = binr.ReadByte();
                if (bt != 0x00)     //expect null byte next
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();    //advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();   //advance 2 bytes
                else
                    return null;

                twobytes = binr.ReadUInt16();
                byte lowbyte = 0x00;
                byte highbyte = 0x00;

                if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
                    lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus
                else if (twobytes == 0x8202)
                {
                    highbyte = binr.ReadByte(); //advance 2 bytes
                    lowbyte = binr.ReadByte();
                }
                else
                    return null;
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
                int modsize = BitConverter.ToInt32(modint, 0);

                int firstbyte = binr.PeekChar();
                if (firstbyte == 0x00)
                {   //if first byte (highest order) of modulus is zero, don't include it
                    binr.ReadByte();    //skip this null byte
                    modsize -= 1;   //reduce modulus buffer size by 1
                }

                byte[] modulus = binr.ReadBytes(modsize);   //read the modulus bytes

                if (binr.ReadByte() != 0x02)            //expect an Integer for the exponent data
                    return null;
                int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                byte[] exponent = binr.ReadBytes(expbytes);

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSAParameters RSAKeyInfo = new RSAParameters();
                RSAKeyInfo.Modulus = modulus;
                RSAKeyInfo.Exponent = exponent;
                RSA.ImportParameters(RSAKeyInfo);

                return RSA;
            }

        }
    }

    private static bool CompareBytearrays(byte[] a, byte[] b)
    {
        if (a.Length != b.Length)
            return false;
        int i = 0;
        foreach (byte c in a)
        {
            if (c != b[i])
                return false;
            i++;
        }
        return true;
    }
}





