import pygame
import random
import sys

#pygame設定の初期化
pygame.init()

#画面設定
screen = pygame.display.set_mode((800, 600))
pygame.display.set_caption("Sugi Run Game")
clock = pygame.time.Clock()


#プレイヤーの生成
class Player():
    width=50
    height=70
    color=(0,0,255)

    def __init__(self,x,y):
        self.rect = pygame.Rect(x,y, Player.width, Player.height)

    def draw(self):
       pygame.draw.rect(screen, Player.color, self.rect)

    def update(self):
        self.speed = 5
        self.rect.y += self.speed

#プレイヤーオブジェクトの生成
player = Player(100, 200)

while True:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            pygame.quit()
            sys.exit()
    
    #画面を毎回リセット
    screen.fill((255, 255, 255))
    player.draw()

    pygame.display.flip()
    clock.tick(60)


