using System.Collections.Generic;
using ConnectApp.constants;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using TextStyle = Unity.UIWidgets.painting.TextStyle;

namespace ConnectApp.components {
    public class CustomTabBar : StatefulWidget {
        public CustomTabBar(
            List<Widget> controllers,
            List<CustomTabBarItem> items,
            Color tabbarBackgroudColor,
            Key key = null
        ) : base(key) {
            this.controllers = controllers;
            this.items = items;
            this.tabbarBackgroudColor = tabbarBackgroudColor;
        }

        public readonly Color tabbarBackgroudColor;
        public readonly List<Widget> controllers;
        public readonly List<CustomTabBarItem> items;

        public override State createState() {
            return new _CustomTabBarState();
        }
    }

    public class _CustomTabBarState : State<CustomTabBar> {
        private PageController _pageController;
        private int _selectedIndex;

        private const int kTabBarHeight = 49;
        private Widget _body;

        public override Widget build(BuildContext context) {
            return new Stack(
                children: new List<Widget> {
                    _contentView(),
                    new Positioned(
                        bottom: MediaQuery.of(context).viewInsets.bottom,
                        left: 0,
                        right: 0,
                        child: _bottomTabBar()
                    )
                }
            );
        }

        private Widget _contentView() {
            return new Container(
                child: new Container(
                    height: MediaQuery.of(context).size.height,
                    color: CColors.Blue,
                    decoration: new BoxDecoration(CColors.background1),
                    child: widget.controllers[_selectedIndex]
                )
            );
        }

        private Widget _bottomTabBar() {
            return new Container(
                decoration: new BoxDecoration(
                    border: Border.all(CColors.Separator),
                    color: widget.tabbarBackgroudColor
                ),
                height: kTabBarHeight,
                child: new Row(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: _buildItems()
                )
            );
        }

        private List<Widget> _buildItems() {
            List<Widget> _widgets = new List<Widget>();
            widget.items.ForEach(item => {
                Widget _bulidItem = new Flexible(
                    child: new Stack(
                        fit: StackFit.expand,
                        children: new List<Widget> {
                            new GestureDetector(
                                onTap: () => {
                                    if (_selectedIndex != item.index) setState(() => _selectedIndex = item.index);
                                },
                                child: new Container(
                                    decoration: new BoxDecoration(
                                        color: Color.clear),
                                    child: new Column(
                                        mainAxisAlignment: MainAxisAlignment.center,
                                        children: new List<Widget> {
                                            new Padding(
                                                padding: EdgeInsets.only(top: 5),
                                                child: new Icon(item.icon, null, item.size,
                                                    _selectedIndex == item.index
                                                        ? item.activeColor
                                                        : item.inActiveColor)
                                            ),
                                            new Padding(
                                                padding: EdgeInsets.only(top: 5),
                                                child: new Text(item.title,
                                                    style: new TextStyle(fontSize: 9,
                                                        color: _selectedIndex == item.index
                                                            ? item.activeColor
                                                            : item.inActiveColor))
                                            ),
                                        }
                                    )
                                )
                            )
                        }
                    )
                );
                _widgets.Add(_bulidItem);
            });

            return _widgets;
        }
    }
}