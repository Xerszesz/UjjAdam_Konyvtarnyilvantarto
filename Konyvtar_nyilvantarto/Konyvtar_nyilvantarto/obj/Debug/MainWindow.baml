   M S B A M L   `   `   `  ����P  LKonyvtar_nyilvantarto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Konyvtar_nyilvantartoKonyvtar_nyilvantarto  5   	   &     Konyvtar_nyilvantarto.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Konyvtar_nyilvantarto     5   	     � Title$  
MainWindow��5   	   $	��459��6   $��807.5��6)   .��5	      � .+�5
   
   �� $
��Left=�6   $	��399��60   $��	10,10,0,0q�6=   $	��Top=�6P   $	��778��6h   .@�5      �� -   5         ��Name$ 
Konyvektab��5      $��Könyvek��6*   .��5      � ���	#FFE5E5E5.+�5      �� -   5         ��Name$ IDdisplaykonyvek��5      $��Right=�68   $��24��6T   $��
0,26,486,0q�6`    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��232��6�   �� 5      $
��Left=�6    $��9,27,0,0q�6;   $
��Wrap=�6M   $	��ID:��6a   $	��Top=�6l   $��23��6�   $��56��6�   �� 5      $
��Left=�6    $��9,55,0,0q�6;   $
��Wrap=�6M   $��Szerző:��6a   $	��Top=�6p   $��23��6�   $��56��6�   �� 5      $
��Left=�6    $��9,83,0,0q�6;   $
��Wrap=�6M   $��Cím:��6a   $	��Top=�6m   $��23��6�   $��56��6�   �� 5      $
��Left=�6    $��
10,106,0,0q�6;   $
��Wrap=�6O   $
��Év:��6c   $	��Top=�6n   $��23��6�   $��56��6�   �� 5      $
��Left=�6    $��
10,134,0,0q�6;   $
��Wrap=�6O   $��Kiadó:��6c   $	��Top=�6q   $��23��6�   $��56��6�   �� 5      -   5        $ Szerzodisplaykonyvek��5      $
��Left=�6<   $��23��6W   $��	55,55,0,0q�6c   $
 Wrap=�6v   $	��Top=�6�   $	��231��6�   �� 5      -   5        $ Cimdisplaykonyvek��5      $
��Left=�69   $��22��6T   $��	55,83,0,0q�6`   $
 Wrap=�6s   $	��Top=�6�   $	��231��6�   �� 5      -   5        $ Evdisplaykonyvek��5      $
��Left=�68   $��23��6S   $��
55,106,0,0q�6_   $
 Wrap=�6s   $	��Top=�6�   $	��136��6�   �� 5      -   5        $ Kiadodisplaykonyvek��5      $
��Left=�6;   $��23��6V   $��
55,134,0,0q�6b   $
 Wrap=�6v   $	��Top=�6�   $	��232��6�   �� 5      $
��Left=�6    $��	9,345,0,0q�6;   $
��Wrap=�6N   $��Kölcsönözhető:��6b   $	��Top=�6x   �� 5      -   5         ��Name$ Kolcsoncheckkonyvek��5      $�� ��6<   $
��Left=�6G   $��
94,345,0,0q�6b   $	��Top=�6v    J� RenderTransformOrigin$ 1.025,2.833&�6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ KonyvekDisplay��5      $
��Left=�67   $	��357��6R   $��	322,4,0,0q�6_   $	��Top=�6r   $	��436��6�   6�   �� 5      -	   5         ��Name$ Könyvekmentés��5      $��Mentés��64   $
��Left=�6E   $��
25,204,0,0q�6`   $	��Top=�6t   $��75��6�   $��93��6�   6�   �� 5      -
   5        $ KönyvekTörlés��5      $��Törlés��64   $
��Left=�6E   $��105,204,0,0q�6`   $	��Top=�6u   $��75��6�   $��93��6�   6�   �� 5      -   5        $ KönyvekÚj��5      $	��Új��60   $
��Left=�6=   $��185,204,0,0q�6X   $	��Top=�6m   $��75��6�   $��93��6�   6�   5      5      �� 5      -   5        $ Tagoktab��5      $��Tagok��6(   .��5       � ���	#FFE5E5E5.+�5!        -   5        $ 
Tagdisplay��5!      $
��Left=�63   $	��351��6N   $��
328,10,0,0q�6[   $	��Top=�6o   $	��434��6�   6�   �� 5"      $
��Left=�6    $��0,26,0,0q�6;   $
��Wrap=�6M   $	��ID:��6a   $	��Top=�6l   �� 5#      $
��Left=�6    $��0,58,0,0q�6;   $
��Wrap=�6M   $��Név:��6a   $	��Top=�6m   �� 5$      $
��Left=�6    $��0,91,0,0q�6;   $
��Wrap=�6M   $��Lakcím:��6a   $	��Top=�6p   �� 5%      -   5        $ IDdisplaytagok��5%      $
��Left=�66   $��23��6Q   $��	19,25,0,0q�6]   $
 Wrap=�6p   $	��Top=�6�   $	��205��6�   �� 5&      -   5        $ Nevdisplaytagok��5&      $
��Left=�67   $��23��6R   $��	29,57,0,0q�6^   $
 Wrap=�6q   $	��Top=�6�   $	��236��6�   �� 5'      -   5        $ Lakcimdisplaytagok��5'      $
��Left=�6:   $��23��6U   $��	44,91,0,0q�6a   $
 Wrap=�6t   $	��Top=�6�   $	��270��6�   �� 5(      -   5        $ 
TagMentés��5(      $��Mentés��60   $
��Left=�6A   $��
10,160,0,0q�6\   $	��Top=�6p   $	��304��6�   $��27��6�   6�   �� 5)      -   5        $ TagTörlés��5)      $��Törlés��60   $
��Left=�6A   $��
10,202,0,0q�6\   $	��Top=�6p   $	��304��6�   $��27��6�   6�   �� 5*      -   5        $ TagÚj��5*      $	��Új��6,   $
��Left=�69   $��
10,244,0,0q�6T   $	��Top=�6h   $	��304��6�   $��27��6�   6�   5+      5,      �� 5-      -   5        $ 
Kolcsontab��5-      $��Kölcsönzés��6*   $��	1,0,-5,-2q�6>   .��5.      � ���	#FFE5E5E5.+�5/        -   5        $ Kolcsonzesdisplay��5/      $
��Left=�6:   $	��351��6U   $��
330,10,0,0q�6b   $	��Top=�6v   $	��432��6�   6�   �� 50      $
��Left=�6    $��	10,36,0,0q�6;   $
��Wrap=�6N   $��Szerző:��6b   $	��Top=�6q   �� 51      $
��Left=�6    $��	10,69,0,0q�6;   $
��Wrap=�6N   $
��Tag:��6b   $	��Top=�6n   �� 52      $
��Left=�6    $��
10,103,0,0q�6;   $
��Wrap=�6O   $��Könyvnek Címe:��6c   $	��Top=�6y   �� 53      -   5        $ szerzodisplaykolcson��53      $
��Left=�6<   $��23��6W   $��	52,35,0,0q�6c   $
 Wrap=�6v   $	��Top=�6�   $	��238��6�   �� 54      -   5        $ tagdisplaykolcson��54      $
��Left=�69   $��23��6T   $��	36,68,0,0q�6`   $
 Wrap=�6s   $	��Top=�6�   $	��206��6�   �� 55      -   5        $ cimdisplaykolcson��55      $
��Left=�69   $��23��6T   $��
99,102,0,0q�6`   $
 Wrap=�6t   $	��Top=�6�   $	��226��6�   �� 56      -   5        $ Kolcsonkeres��56      $��Keres��63   $
��Left=�6C   $��
10,341,0,0q�6^   $	��Top=�6r   $	��304��6�   6�   57      58      59      5;      5<      