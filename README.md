Dotlib Encryption
=================

Biblioteca de criptografia e descriptofrafia.

## Criptografia simétrica
--------------------------

### Critografar uma string

```csharp
var plainText = "this is my plain text";   // Texto a ser criptografado
var passPhrase = "this is my pass phrase"; // Chave de criptografia

var encrypted = Symmetric.Encrypt(plainText, passPhrase);
```

### Descritografar uma string

```csharp
var encryptedText = "VVBXjy/jCQsBjv8hlyl0lrhcRuyaWzorLcLp86Zkqx8="; // Texto criptografado
var passPhrase = "this is my pass phrase";                          // Chave de criptografia

var decrypted = Symmetric.Decrypt(encryptedText, passPhrase);
```

Referências:

 * Criptografia simétrica: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.symmetricalgorithm?view=netframework-4.7.2
 * Criptgrafia assimétrica: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.asymmetricalgorithm?view=netframework-4.7.2