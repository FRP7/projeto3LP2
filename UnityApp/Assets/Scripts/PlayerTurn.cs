﻿using System;
using System.Collections.Generic;
using Common;

public class PlayerTurn
{
    private GameState gameState = new GameState();

    public List<Tuple<int, SlotTypes, SlotColors>> GetPlayerLegalPlays
    {
        get => ServiceLocator.GetService<List<Tuple<int, SlotTypes, SlotColors>>>();
        set => ServiceLocator.GetService<List<Tuple<int, SlotTypes, SlotColors>>>();
    }

    public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
    {
        get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
    }

    public bool IsPlayed { get; set; }

    public void PlayerPlay(int piece, int slot, bool isPlayerWhite)
    {
        if (ChoosePiece(piece, slot))
        {
            if (CheckIfLegal(piece, slot))
            {
                PlayPiece(piece, slot, isPlayerWhite);
                IsPlayed = true;
            }
        }
    }

    private bool ChoosePiece(int piece, int slot)
    {
        gameState.CheckPlayerLegalPlays(piece);

        return true;
    }

    private bool CheckIfLegal(int piece, int slot)
    {
        return gameState.CheckIfLegal(piece, slot);
    }

    private void PlayPiece(int piece, int slot, bool isPlayerWhite)
    {
        if (isPlayerWhite)
        {
            gameState.PlayerPlay(piece, slot, true);
        }
        else
        {
            gameState.PlayerPlay(piece, slot, false);
        }
    }

    public PlayerTurn()
    {
        IsPlayed = false;
    }
}