System.define("VoidSharp.VoidLib", {
    Notify = function (upper, text, color, length)
        VoidLib.Notify(upper, text, color:ToGmodColor(), length)
    end,
    Notify1 = function (ply, upper, text, color, length)
        VoidLib.Notify(ply, upper, text, color:ToGmodColor(), length)
    end,
    RegisterAddon = function (addonName, addonID, license)
        VoidLib.Tracker:RegisterAddon(addonName, addonID, license)
    end,
    GetLanguagePhrases = function (addonName)
        
    end
})