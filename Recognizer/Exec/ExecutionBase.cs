﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LAIR.ResourceAPIs.WordNet;
using Recognizer.NLP;
using Recognizer.Glossary;
using Recognizer.Helper;
using Recognizer.BoW;

namespace Recognizer.Exec
{
    abstract class ExecutionBase : IExecution
    {
        protected readonly WordNetEngine wordnet;
        protected readonly INLPService nlp;

        protected BagOfWords bow;

        public ExecutionBase(WordNetEngine wordnet, INLPService nlp)
        {
            this.wordnet = wordnet;
            this.nlp = nlp;
        }

        protected virtual SynSet SelectSynset(string word, POS pos)
        {
            WordNetEngine.POS wordnetPOS = pos.ForWordnet();
            return (wordnetPOS == WordNetEngine.POS.None) ? null : wordnet.GetMostCommonSynSet(word, wordnetPOS);
        }

        #region IExecution Members

        public abstract void Run(string input, IGlossary glossary);

        #endregion
    }
}
