﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Core.Delegates
{
    public delegate void ScoreAddedDelegate(object sender, EventArgs args);
    public delegate void ZeroScoreWarningDelegate(object sender, EventArgs args);
}
