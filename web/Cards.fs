namespace Cards

/// Масть
type Suit =
    /// Черви
    | Heart
    /// Буби
    | Diamond
    /// Пики
    | Spade
    /// Трефы
    | Club
and PlayingCards =
    /// Туз
    | Ace of Suit
    /// Король
    | King of Suit
    /// Дама
    | Queen of Suit
    /// Валет
    | Jack of Suit
    /// Числовая карта
    | ValueCard of int * Suit

module Utils =
    /// Генератор карточного набора
    let CardDeckGenerator =
        [
            for suit in [ Heart; Diamond; Spade; Club ] do
                yield Ace(suit)
                yield King(suit)
                yield Queen(suit)
                yield Jack(suit)
                for value in 2 .. 10 do
                    yield ValueCard(value, suit)
        ]
    /// Получить масть карты    
    let GetSuitFormCard (card: PlayingCards) =
        match card with
            | ValueCard(_, s) | Ace(s) | King(s) | Queen(s) | Jack(s) -> s
    /// Получить список карт по масти
    let GetCardsForSuit (suit:Suit) =
        List.where (fun card -> GetSuitFormCard(card) = suit)
    /// Получить список карт по значению
    let GetCardsForValue (value: PlayingCards) =
        List.where (fun (card: PlayingCards) -> card.GetType().FullName = value.GetType().FullName)