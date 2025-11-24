# Batalha Espacial 🚀

Este é o repositório do trabalho da disciplina de **CCC300 - Computação Gráfica e Realidade Virtual**, ministrada pelo Prof. Dr. Rafael Rieder.

## 📖 Sobre o Jogo

**Batalha Espacial** é um jogo 2D simples onde o jogador pilota uma nave espacial com o objetivo de destruir alvos, como naves inimigas e asteroides, dentro de uma área limitada e em um tempo pré-determinado. Para vencer, é preciso abater um número mínimo de inimigos e alcançar o ponto de chegada em determinado período de tempo.

O jogo foi desenvolvido utilizando a game engine Unity, conforme a recomendação do trabalho.

## 👥 Equipe

* Érick Landim de Paula - 185329
* Fernanda Japur Ihjaz - 205657
* Pedro Kuntz Dos Santos - 185392

## ✨ Funcionalidades

### 🛸 Sistemas do Jogador (Player Systems)
- Criação completa do **Prefab da Nave** do jogador.  
- **Controles personalizados de movimento**, incluindo:  
  - Aceleração constante ajustável via teclado.  
  - Rotação livre da nave (cima/baixo/lateral) com a câmera seguindo o jogador.  
- **Sistema de tiro do jogador**: disparo via tecla ou mouse, com projéteis se movendo em linha reta na direção correta.  
- **Sistema de Vida e Dano**, incluindo colisões com inimigos e asteroides.  

---

### 👾 Sistemas de Inimigos e Mundo (Enemy & World Systems)
- Criação dos **Prefabs de Inimigos** e **Asteroides**.  
- Implementação de múltiplos padrões de movimentação:  
  - Linha reta  
  - Perseguição ao jogador  
  - Movimentos em curva ou com trajetórias pré-definidas  
- **Sistema de ataque inimigo**, com disparos próprios.  
- **Vida dos inimigos e asteroides**, definindo quantos tiros são necessários para destruí-los.  
- **Efeitos visuais de explosão** ao eliminar inimigos ou obstáculos.  

---

### 🎮 Fluxo do Jogo e Interface (Game Flow & UI Systems)
- Implementação do **Game Manager**, responsável por:  
  - Timer da fase.  
  - Contador de inimigos destruídos.  
- **Lógica de Vitória e Derrota**:  
  - **Vitória**: destruir número de inimigos específico, chegar ao destino e ter tempo restante.  
  - **Derrota**: jogador morrer ou tempo acabar.  
- Construção da **área de jogo limitada**, incluindo ponto inicial e **linha de chegada** com trigger.  
- **Menus e UI**:  
  - Menu Principal com seleção de dificuldade (Fácil, Normal e Difícil).  
  - Tela de Game Over e Tela de Vitória.  
  - Ranking simples baseado em inimigos derrotados.  
  - Timer  
  - Pontuação (abates)  
  - Vida do jogador  
- **Áudio do jogo**, incluindo músicas e efeitos sonoros.  

## 🎮 Como Jogar

### **🎮 Controles**
| Ação | Tecla |
| :--- | :--- |
| **Movimentar Nave (Player)** | Setas direita ou esquerda(ou W/S) |
| **Rotacionar Nave** | Setas cima e baixo (ou A/D) |
| **Boost (3 segundos)** | Espaço |
| **Atirar/Disparar** | Botão direito do mouse ou Ctrl |


### 🎯 Objetivo
Para vencer, o jogador deve cumprir três condições simultaneamente:
1. **Sobreviver:** Não ser destruído pelos inimigos ou asteroids.
2. **Derrotar Inimigos:** Eliminar uma quantidade mínima de inimigos (dependendo da dificuldade).
3. **Alcançar a Meta:** Chegar a uma distância específica antes que o tempo acabe.

### 💀 Níveis de Dificuldade
- **Fácil**
    - 5 naves inimigas devem ser abatidas
- **Normal**
    - 10 naves inimigas devem ser abatidas
- **Difícil**
    - 15 naves inimigas devem ser abatidas

## 📥 Downloads

* **[Link para baixar o executável do jogo](https://drive.google.com/drive/folders/1jWu9OzdC3p0zlI6jV_F1hz3e0Cdk47XD?usp=sharing)**
* **[Link para o vídeo de demonstração](https://youtube.com.br)**