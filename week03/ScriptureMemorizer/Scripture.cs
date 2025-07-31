using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random = new Random();

    public Scripture(Reference Reference, string text)
    {
        reference = Reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int numbertoHide = 2)
    {
        var available = words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < numbertoHide && available.Count > 0; i++)
        {
            int index = random.Next(available.Count);
            available[index].Hide();
            available.RemoveAt(index);
        }
    }

   public string GetDisplayText()
{
    var referenceText = reference.GetDisplayText();
    var wordsText = string.Join(" ", words.Select(w => w.GetDisplayText()));
    return $"{referenceText} {wordsText}\n";
}

    public bool IsCompletelyHidden()
    {
        return words.All(w => w.IsHidden());
    }
}