using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using Photon.Pun;
using Photon.Realtime;

public static class PhotonExtensions {

    private static readonly Dictionary<string, string> SPECIAL_PLAYERS = new() {
        ["cf03abdb5d2ef1b6f0d30ae40303936f9ab22f387f8a1072e2849c8292470af1"] = "ipodtouch0218",
        ["d5ba21667a5da00967cc5ebd64c0d648e554fb671637adb3d22a688157d39bf6"] = "mindnomad",
        ["95962949aacdbb42a6123732dabe9c7200ded59d7eeb39c889067bafeebecc72"] = "MPS64",
        ["7e9c6f2eaf0ce11098c8a90fcd9d48b13017667e33d09d0cc5dfe924f3ead6c1"] = "Fawndue",
        ["3965db638c65cca32e921e56e0b5a2c0bb063b13d653d84d66ed275cec739d3b"] = "Lust",
        ["0e702b2b49c36499e1c1ce5183439e2ff7d7e47f0b44b3c077a6457ce949556c"] = "MrLuigi",
    };

    public static bool IsMineOrLocal(this PhotonView view) {
        return !view || view.IsMine;
    }

    public static bool HasRainbowName(this Player player) {
        if (player == null || player.UserId == null)
            return false;

        byte[] bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(player.UserId));
        StringBuilder sb = new();
        foreach (byte b in bytes)
            sb.Append(b.ToString("X2"));

        string hash = sb.ToString().ToLower();
        return SPECIAL_PLAYERS.ContainsKey(hash) && player.NickName == SPECIAL_PLAYERS[hash];
    }

    //public static void RPCFunc(this PhotonView view, Delegate action, RpcTarget target, params object[] parameters) {
    //    view.RPC(nameof(action), target, parameters);
    //}
}